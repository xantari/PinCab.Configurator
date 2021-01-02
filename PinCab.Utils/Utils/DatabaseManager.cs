using Ipdb.Models;
using Newtonsoft.Json;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VIrtualPinball.Database.Models;

namespace PinCab.Utils.Utils
{

    public class DatabaseManager
    {
        private ProgramSettings _settings { get; set; }
        private ProgramSettingsManager _settingManager = new ProgramSettingsManager();

        public VpsSpreadsheetDatabase VpsDatabase { get; private set; }
        public VpinballDatabase VpinballDatabase { get; private set; }
        public VpForumsDatabase VpforumDatabase { get; private set; }
        public VpUniverseDatabase VpUniverseDatabase { get; private set; }
        public IpdbDatabase IpdbDatabase { get; private set; }

        public const string ToolName = "Database Manager";

        private List<string> _fileContentsArray { get; set; } = new List<string>();
        private string databaseFolder = ApplicationHelpers.GetApplicationFolder() + "\\Databases";
        private string vpfDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpforumdatabase.json";
        private string vpsDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpsdatabase.json";
        private string vpDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpinballdatabase.json";
        private string vpuDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpuniversedatabase.json";
        private string ipdbDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\ipdbdatabase.json";

        private ReportProgressDelegate _reportProgress;

        public DatabaseManager(ReportProgressDelegate reportProgress = null)
        {
            _settings = _settingManager.LoadSettings();
            _reportProgress = reportProgress;
        }

        public bool IsValid(DatabaseType type)
        {
            if (type == DatabaseType.VPForums)
            {
                if (string.IsNullOrEmpty(_settings.VPForumsDatabaseUrl))
                {
                    Log.Information("{toolname}: Missing VPForums Database URL in settings.", ToolName);
                    return false;
                }
            }
            else if (type == DatabaseType.VPinball)
            {
                if (string.IsNullOrEmpty(_settings.VPinballDatabaseUrl))
                {
                    Log.Information("{toolname}: Missing VPinball Database URL in settings.", ToolName);
                    return false;
                }
            }
            else if (type == DatabaseType.VPSSpreadsheet)
            {
                if (string.IsNullOrEmpty(_settings.VPSSpreadsheetUrl))
                {
                    Log.Information("{toolname}: Missing VPS Spreadsheet Database URL in settings.", ToolName);
                    return false;
                }
            }
            else if (type == DatabaseType.VPUniverse)
            {
                if (string.IsNullOrEmpty(_settings.VPUniverseDatabaseUrl))
                {
                    Log.Information("{toolname}: Missing VP Universe Database URL in settings.", ToolName);
                    return false;
                }
            }
            else if (type == DatabaseType.IPDB)
            {
                if (string.IsNullOrEmpty(_settings.IPDBDatabaseUrl))
                {
                    Log.Information("{toolname}: Missing IPDB Database URL in settings.", ToolName);
                    return false;
                }
            }
            return true;
        }

        public delegate void ReportProgressDelegate(int percentage);

        public ToolResult RefreshAllDatabases()
        {
            if (!File.Exists(vpfDatabasePath) ||
              !File.Exists(vpsDatabasePath) ||
              !File.Exists(vpDatabasePath) ||
              !File.Exists(vpuDatabasePath) ||
              !File.Exists(ipdbDatabasePath)
            ) //Force a refersh if one or more of the databases disappeared from the file system
            {
                _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow.AddMinutes((_settings.DatabaseUpdateRecheckMinutes * -1) - 1);
            }
            var vpfResult = DownloadDatabase(DatabaseType.VPForums);
            _reportProgress?.Invoke(20);
            var vpuResult = DownloadDatabase(DatabaseType.VPUniverse);
            _reportProgress?.Invoke(40);
            var vpsResult = DownloadDatabase(DatabaseType.VPSSpreadsheet);
            _reportProgress?.Invoke(60);
            var vpResult = DownloadDatabase(DatabaseType.VPinball);
            _reportProgress?.Invoke(80);
            var ipdbResult = DownloadDatabase(DatabaseType.IPDB);
            _reportProgress?.Invoke(100);
            var result = new ToolResult(ToolName);
            result.Messages.AddRange(vpfResult?.Messages);
            result.Messages.AddRange(vpuResult?.Messages);
            result.Messages.AddRange(vpsResult?.Messages);
            result.Messages.AddRange(vpResult?.Messages);
            result.Messages.AddRange(ipdbResult?.Messages);
            _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow;
            _settingManager.SaveSettings(_settings);
            result.Messages.Add(new ValidationMessage("Database refresh completed.", MessageLevel.Information));
            return result;
        }

        public ToolResult DownloadDatabase(DatabaseType type)
        {
            var result = new ToolResult();

            if (_settings.LastDatabaseRefreshTimeUtc < DateTime.UtcNow.AddMinutes(_settings.DatabaseUpdateRecheckMinutes * -1))
            {
                if (type == DatabaseType.VPForums)
                {
                    DownloadDatabase(type, _settings.VPForumsDatabaseUrl, vpfDatabasePath);
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPForumsDatabaseUrl} to {vpfDatabasePath}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPSSpreadsheet)
                {
                    DownloadDatabase(type, _settings.VPSSpreadsheetUrl, vpsDatabasePath);
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPSSpreadsheetUrl} to {vpsDatabasePath}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPinball)
                {
                    DownloadDatabase(type, _settings.VPinballDatabaseUrl, vpDatabasePath);
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPinballDatabaseUrl} to {vpDatabasePath}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPUniverse)
                {
                    DownloadDatabase(type, _settings.VPUniverseDatabaseUrl, vpuDatabasePath);
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPUniverseDatabaseUrl} to {vpuDatabasePath}", MessageLevel.Information));
                }
                else if (type == DatabaseType.IPDB)
                {
                    DownloadDatabase(type, _settings.IPDBDatabaseUrl, ipdbDatabasePath);
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.IPDBDatabaseUrl} to {ipdbDatabasePath}", MessageLevel.Information));
                }
            }
            else
            {
                var nextRefreshTime = _settings.LastDatabaseRefreshTimeUtc.AddMinutes(_settings.DatabaseUpdateRecheckMinutes);
                result.Messages.Add(new ValidationMessage($"Not at recheck minutes threshold. Next Refresh: {nextRefreshTime}. Database: {type}", MessageLevel.Information));
                Log.Information("{toolname}: Not at recheck minutes threshold. Next Refresh: {date}.", ToolName, nextRefreshTime);
            }
            return result;
        }

        private void DownloadDatabase(DatabaseType type, string downloadUrl, string downloadPath)
        {
            using (WebClient wc = new WebClient())
            {
                //wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFile(new Uri(downloadUrl), downloadPath);
            }
        }

        public void LoadAllDatabases()
        {
            var appFolder = ApplicationHelpers.GetApplicationFolder();
            if (File.Exists(vpfDatabasePath))
            {
                VpforumDatabase = JsonConvert.DeserializeObject<VpForumsDatabase>(File.ReadAllText(vpfDatabasePath));
            }
            if (File.Exists(vpsDatabasePath))
            {
                VpsDatabase = JsonConvert.DeserializeObject<VpsSpreadsheetDatabase>(File.ReadAllText(vpsDatabasePath));
            }
            if (File.Exists(vpDatabasePath))
            {
                VpinballDatabase = JsonConvert.DeserializeObject<VpinballDatabase>(File.ReadAllText(vpDatabasePath));
            }
            if (File.Exists(vpuDatabasePath))
            {
                VpUniverseDatabase = JsonConvert.DeserializeObject<VpUniverseDatabase>(File.ReadAllText(vpuDatabasePath));
            }
            if (File.Exists(ipdbDatabasePath))
            {
                IpdbDatabase = JsonConvert.DeserializeObject<IpdbDatabase>(File.ReadAllText(ipdbDatabasePath));
            }
        }

        public List<DatabaseBrowserEntry> GetAllEntries()
        {
            List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();
            _reportProgress?.Invoke(10);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPForums));
            _reportProgress?.Invoke(30);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPUniverse));
            _reportProgress?.Invoke(50);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPSSpreadsheet));
            _reportProgress?.Invoke(70);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPinball));
            _reportProgress?.Invoke(100);
            return entries;
        }

        public List<DatabaseBrowserEntry> GetEntrysByDatabase(DatabaseType type)
        {
            List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();
            if (IsValid(type))
            {
                if (type == DatabaseType.VPForums)
                {
                    if (VpforumDatabase == null)
                    {
                        Log.Warning("{tool}: VPForum database not loaded. Did you load the databse first?", ToolName);
                        return entries;
                    }
                    entries.AddRange(GetVpForumsEntries());
                }
                else if (type == DatabaseType.VPinball)
                {
                    if (VpinballDatabase == null)
                    {
                        Log.Warning("{tool}: VPinball database not loaded. Did you load the databse first?", ToolName);
                        return entries;
                    }
                }
                else if (type == DatabaseType.VPSSpreadsheet)
                {
                    if (VpsDatabase == null)
                    {
                        Log.Warning("{tool}: VPSSpreadsheet database not loaded. Did you load the databse first?", ToolName);
                        return entries;
                    }
                }
                else if (type == DatabaseType.VPUniverse)
                {
                    if (VpUniverseDatabase == null)
                    {
                        Log.Warning("{tool}: VPUniverse database not loaded. Did you load the databse first?", ToolName);
                        return entries;
                    }
                }
                return entries;
            }
            return null;
        }

        private List<DatabaseBrowserEntry> GetVpForumsEntries()
        {
            List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();
            foreach (var table in VpforumDatabase.VpGames)
            {
                var entry = GetVpGameEntry(table, DatabaseType.VPForums);
                entries.Add(entry);
            }

            foreach(var item in VpforumDatabase.BackglassFiles)
            {
                var entry = GetBackglassEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
            }

            foreach (var item in VpforumDatabase.MediaPackFiles)
            {
                var entry = GetMediaPackEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
            }

            foreach (var item in VpforumDatabase.RomFiles)
            {
                var entry = GetRomEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
            }

            foreach (var item in VpforumDatabase.TopperFiles)
            {
                var entry = GetTopperEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
            }

            foreach (var item in VpforumDatabase.WheelArtFiles)
            {
                var entry = GetWheelEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
            }

            //Rescan the related entries and fill in missing tags that we were able to find for the URL in a different
            //area of the database

            return entries;
        }

        private DatabaseBrowserEntry GetVpGameEntry(VpGame file, DatabaseType dbType)
        {
            var entry = new DatabaseBrowserEntry()
            {
                Authors = file.Authors,
                ChangeLog = file.ChangeLog,
                DatabaseType = dbType,
                Description = file.Description,
                IpdbId = file.TableInfo?.IpdbNumber,
                Title = file.TableName,
                Type = DatabaseEntryType.Table,
                Url = file.Url,
                Version = file.Version
            };
            entry.Tags.AddRange(file.TableInfo.ConvertTableInfoToTags());
            entry.Tags.AddRange(file.Tags);
            if (file.Date.HasValue) //Start with date
                entry.LastUpdated = file.Date.Value;
            if (file.CreateDate.HasValue) //Start with create date
                entry.LastUpdated = file.CreateDate.Value;
            if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                entry.LastUpdated = file.LastUpdatedDate.Value;
            if (!string.IsNullOrEmpty(file.Features))
                entry.Description += "\r\n\r\n" + file.Features;
            entry.Tags.AddRange(file.FeatureFlags.ConvertFeatureFlagsToTags());

            List<string> TagsByIpdbNumber = new List<string>();
            if (entry.IpdbId.HasValue)
                entry.Tags.AddRange(GetTagsByIpdbNumber(entry.IpdbId.Value));

            entry.Tags = entry.Tags.NormalizeTagList();

            //Get related media
            if (file.BackglassFiles != null)
            {
                foreach (var backglass in file.BackglassFiles)
                {
                    var relatedEntry = GetBackglassEntry(backglass, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.MediaPackFiles != null)
            {
                foreach (var mediapack in file.MediaPackFiles)
                {
                    var relatedEntry = GetMediaPackEntry(mediapack, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.PinsoundFiles != null)
            {
                foreach (var pinsoundFile in file.PinsoundFiles)
                {
                    var relatedEntry = GetPinsoundEntry(pinsoundFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.PovFiles != null)
            {
                foreach (var povFile in file.PovFiles)
                {
                    var relatedEntry = GetPovEntry(povFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.PupPackFiles != null)
            {
                foreach (var pupPackFile in file.PupPackFiles)
                {
                    var relatedEntry = GetPupPackEntry(pupPackFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.RomFiles != null)
            {
                foreach (var romFile in file.RomFiles)
                {
                    var relatedEntry = GetRomEntry(romFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.SoundFiles != null)
            {
                foreach (var soundFile in file.SoundFiles)
                {
                    var relatedEntry = GetSoundEntry(soundFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.TopperFiles != null)
            {
                foreach (var topperFile in file.TopperFiles)
                {
                    var relatedEntry = GetTopperEntry(topperFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            if (file.WheelArtFiles != null)
            {
                foreach (var wheelFile in file.WheelArtFiles)
                {
                    var relatedEntry = GetWheelEntry(wheelFile, dbType);
                    relatedEntry.IpdbId = entry.IpdbId;
                    relatedEntry.Tags.AddRange(TagsByIpdbNumber);
                    entry.RelatedEntries.Add(relatedEntry);
                }
            }

            return entry;
        }

        private DatabaseBrowserEntry GetWheelEntry(WheelArtFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.Wheel
                };

                entry.Tags.Add("Wheel");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetTopperEntry(TopperFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.Topper
                };

                entry.Tags.Add("Topper");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetSoundEntry(SoundFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.OtherFrontEndMedia
                };

                entry.Tags.Add("Sound File");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetRomEntry(RomFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.RomName,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.ROM
                };

                entry.Tags.Add("ROM");

                if (file.AltColor || file.Color)
                    entry.Tags.Add("Color");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetPupPackEntry(PupPackFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.PupPack
                };

                entry.Tags.Add("Pup Pack");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetPovEntry(PovFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.POV
                };

                entry.Tags.Add("POV");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetPinsoundEntry(PinsoundFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.Pinsound
                };

                entry.Tags.Add("Pinsound");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetMediaPackEntry(MediaPackFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.OtherFrontEndMedia
                };

                entry.Tags.Add("Media Pack");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private DatabaseBrowserEntry GetBackglassEntry(BackglassFile file, DatabaseType dbType)
        {
            if (file != null)
            {
                var entry = new DatabaseBrowserEntry()
                {
                    Title = file.Title,
                    Url = file.Url,
                    Authors = file.Authors,
                    DatabaseType = dbType,
                    Description = file.Description,
                    Version = file.Version,
                    Type = DatabaseEntryType.Backglass
                };

                entry.Tags.Add("Backglass");

                if (file.Date.HasValue) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue) //If last updated is populated move to that instead
                    entry.LastUpdated = file.LastUpdatedDate.Value;

                return entry;
            }
            return null;
        }

        private List<string> GetTagsByIpdbNumber(int ipdbId)
        {
            var list = new List<string>();
            if (IpdbDatabase != null)
            {
                var entry = IpdbDatabase.Data.FirstOrDefault(p => p.IpdbId == ipdbId);
                if (entry != null)
                {
                    if (!string.IsNullOrEmpty(entry.ManufacturerShortName))
                        list.Add(entry.ManufacturerShortName);
                    if (entry.DateOfManufacture.HasValue)
                        list.Add(entry.DateOfManufacture.Value.Year.ToString());
                    if (!string.IsNullOrEmpty(entry.TypeShortName))
                        list.Add(entry.TypeShortName);
                    if (!string.IsNullOrEmpty(entry.Theme))
                        list.Add(entry.Theme);
                    if (!string.IsNullOrEmpty(entry.MPU))
                        list.Add(entry.MPU);
                }
            }
            return list;
        }
    }
}
