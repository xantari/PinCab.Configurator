using Ipdb.Models;
using Newtonsoft.Json;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public List<DatabaseBrowserEntry> Entries { get; private set; }


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
            Entries = new List<DatabaseBrowserEntry>();
        }

        public ProgramSettings Settings { get { return _settings; } }

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
            var entries = new List<DatabaseBrowserEntry>();
            _reportProgress?.Invoke(10);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPForums));
            _reportProgress?.Invoke(30);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPUniverse));
            _reportProgress?.Invoke(50);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPSSpreadsheet));
            _reportProgress?.Invoke(70);
            entries.AddRange(GetEntrysByDatabase(DatabaseType.VPinball));
            _reportProgress?.Invoke(100);
            Entries = entries;
            return entries;
        }

        public List<ValidationMessage> GetDatabaseVersionMessages()
        {
            var entries = new List<ValidationMessage>();
            if (VpforumDatabase != null)
            {
                entries.Add(new ValidationMessage()
                {
                    Level = MessageLevel.Information,
                    Message = "VPForum Database Last Updated (UTC): " + VpforumDatabase.LastRefreshDateUtc + " Local: " + VpforumDatabase.LastRefreshDateUtc.ToLocalTime()
                });
            }
            if (VpinballDatabase != null)
            {
                entries.Add(new ValidationMessage()
                {
                    Level = MessageLevel.Information,
                    Message = "VPinball Database Last Updated (UTC): " + VpinballDatabase.LastRefreshDateUtc + " Local: " + VpinballDatabase.LastRefreshDateUtc.ToLocalTime()
                });
            }
            if (VpsDatabase != null)
            {
                entries.Add(new ValidationMessage()
                {
                    Level = MessageLevel.Information,
                    Message = "VPS Spreadsheet Database Last Updated (UTC): " + VpsDatabase.LastRefreshDateUtc + " Local: " + VpsDatabase.LastRefreshDateUtc.ToLocalTime()
                });
            }
            if (VpUniverseDatabase != null)
            {
                entries.Add(new ValidationMessage()
                {
                    Level = MessageLevel.Information,
                    Message = "VPUniverse Database Last Updated (UTC): " + VpUniverseDatabase.LastRefreshDateUtc + " Local: " + VpUniverseDatabase.LastRefreshDateUtc.ToLocalTime()
                });
            }

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

            foreach (var item in VpforumDatabase.BackglassFiles)
            {
                var entry = GetBackglassEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
                entries.Add(entry);
            }

            foreach (var item in VpforumDatabase.MediaPackFiles)
            {
                var entry = GetMediaPackEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
                entries.Add(entry);
            }

            foreach (var item in VpforumDatabase.RomFiles)
            {
                var entry = GetRomEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
                entries.Add(entry);
            }

            foreach (var item in VpforumDatabase.TopperFiles)
            {
                var entry = GetTopperEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
                entries.Add(entry);
            }

            foreach (var item in VpforumDatabase.WheelArtFiles)
            {
                var entry = GetWheelEntry(item, DatabaseType.VPForums);
                var relatedGame = entries.FirstOrDefault(c => c.Type == DatabaseEntryType.Table && c.RelatedEntries.Any(g => g.Url == entry.Url));
                if (relatedGame != null) //Create the reverse link to the game
                    entry.RelatedEntries.Add(relatedGame);
                entries.Add(entry);
            }

            //Rescan the related entries and fill in missing tags that we were able to find for the URL in a different
            //area of the database

            return entries;
        }

        /// <summary>
        /// Attempts to normalize some of the tags and variations of tags to limit the tag list... lots of work to do here
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private string NormalizeTag(string tag)
        {
            var t = tag.ToLower();
            if (t == "wheel" || t == "wheel image")
                t = "Wheel";
            else if (t == "4k" || t == "4k;")
                t = "4K";
            else if (t.Contains("alvin g"))
                t = "Alvin G";
            else if (t == "b2s" || t == "b2s backglass" || t == "backglass" || t == "db2s" || t == "db2sdt" || t == "direct2bs" ||
            t == "b2s fullscreen table" || t == "b2b")
                t = "B2S";
            else if (t == "dof")
                t = "DOF";
            else if (t == "em" || t == "em alternate" || t == "em electro mechanical" || t == "em table" || t == "em tables"
                || t == "ems" || t == "electro" || t == "electromechanical")
                t = "EM (Electro Mechanical)";
            else if (t == "dt")
                t = "Desktop";
            else if (t.Contains("data east") || t.Contains("dataeast"))
                t = "Data East";
            else if (t == "(bailey" || t == "bailey")
                t = "Bailey";
            else if (t == "scifi" || t == "sci-fi" || t == "science fiction")
                t = "Sci-Fi";
            else if (t == "fullscreen")
                t = "Full Screen";
            else if (t.Contains("gottieb") || t.Contains("gottlieb") || t.Contains("gotlieb"))
                t = "Gottlieb";
            else if (t.Contains("adventure"))
                t = "Adventure";
            else if (t.Contains("dancing"))
                t = "Dancing";
            else if (t.Contains("desktop"))
                t = "Desktop";
            else if (t.Contains("aircraft"))
                t = "Aircraft";
            else if (t.Contains("american history"))
                t = "American History";
            else if (t.Contains("american places"))
                t = "American Places";
            else if (t.Contains("american west"))
                t = "American West";
            else if (t.Contains("amusement park"))
                t = "Amusement Park";
            else if (t.Contains("batman"))
                t = "Batman";
            else if (t.Contains("bally"))
                t = "Bally";
            else if (t.Contains("fantasy"))
                t = "Fantasy";
            else if (t.Contains("adventure"))
                t = "Adventure";
            else if (t.Contains("billiards"))
                t = "Billiards";
            else if (t.Contains("physmod") || t == "vp9_physmod")
                t = "Physmod";
            else if (t.Contains("sports"))
                t = "Sports";
            else if (t == "ss" || t == "solid state" || t == "solid")
                t = "SS (Solid State)";
            else if (t.Contains("spinball"))
                t = "Spinball";
            else if (t.Contains("stern"))
                t = "Stern";
            else if (t.Contains("taito"))
                t = "Taito";
            else if (t == "rom")
                t = "ROM";
            else if (t == "sam")
                t = "SAM";
            else if (t == "dmd")
                t = "DMD";
            else if (t.Contains("original"))
                t = "Original";
            else if (t.Contains("williams") || t.Contains("willaims") || t.Contains("wiliiams"))
                t = "Williams";
            else if (t.Contains("widebody") || t.Contains("wide body"))
                t = "Wide Body";
            else if (t.Contains("zaccaria"))
                t = "Zaccaria";
            else if (t.Contains("atari"))
                t = "atari";
            else if (t.Contains("cartoon"))
                t = "Cartoon";
            else if (t.Contains("celebrities"))
                t = "Celebrities";
            else if (t.Contains("licensed theme"))
                t = "Licensed Theme";
            else if (t.Contains("licensed"))
                t = "Licensed Theme";
            else if (t == "fss")
                t = "FSS";
            else if (t == "ssf")
                t = "SSF";
            else if (t == "visual pinball vr" || t == "vpvr" || t == "vr room" || t == "vr game room" || t == "vr tables"
                || t == "vpx vr"
            )
                t = "VR";
            else if (t == "virtual pinball x" || t == "visual pinball 10" || t == "visual pinball x" || t == "vp 10" || t == "vpx"
                || t == "vp8 to vpx conversion" || t == "vp8/vp9 to vpx conversion" || t == "vp9 to vpx conversion"
                || t == "vpx 10.6" || t == "vp10" || t.Contains("vpx")
            )
                t = "VPX";
            else if (t == "vtp 9.9.5" || t == "vp92" || t == "vp915" || t== "vpinmame 9 recreations" || t == "vpinmame 9.x recreations"
                || t == "vp9 fs cabinet b2s table." || t == "vp9" || t == "vp 9" || t == "vp 9.x" || t == "visual pinball 9"
                || t == "bs70 vp 9.x cabinet fs b2s" || t == "bs80 vp 9.x cabinet fs b2s" || t == "vp9.2"
            )
                t = "VP9";
            else if (tag.StartsWith("@")) //Filter out @author tags (we have those in other fields)
                return null;
            else if (tag.IsNumeric() && tag.Length > 4) //Remove bad year tags
                return null;
            //If the first character is not upper case, 
            //upper case it to standardize a lot of combinations of say "arabian" == "Arabian", "atari" == "Atari"
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            t = textInfo.ToTitleCase(t);
            return t;
        }


        public HashSet<string> GetAllTags(List<DatabaseBrowserEntry> entries)
        {
            var tags = new HashSet<string>();
            _reportProgress?.Invoke(50);
            if (Entries == null)
            {
                Log.Warning("{tool}: Database not loaded yet. Load database using GetAllEntries()", ToolName);
                return tags;
            }
            foreach (var entry in entries)
            {
                var entryTags = GetTags(entry);
                foreach (var itm in entryTags)
                    tags.Add(itm);
            }
            _reportProgress?.Invoke(100);
            return tags;
        }

        private HashSet<string> GetTags(DatabaseBrowserEntry entry)
        {
            var tags = new HashSet<string>();
            if (entry.Tags != null)
            {
                foreach (var tag in entry.Tags)
                    tags.Add(tag);
            }
            if (entry.RelatedEntries != null)
            {
                foreach (var relatedEntry in entry.RelatedEntries)
                {
                    var relatedTags = GetTags(relatedEntry); //recursively traverse all entries
                    foreach (var tag in relatedTags)
                        tags.Add(tag);
                }
            }
            return tags;
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
            foreach (var tag in file.Tags)
            {
                if (!entry.Title.ToLower().Contains(tag.ToLower()) //Exclude tags that are part of the title
                    && !entry.Authors.ToLower().Contains(tag.ToLower()) //Exclude tags that are also in the author field
                )
                {
                    var t = NormalizeTag(tag);
                    if (!string.IsNullOrEmpty(t))
                        entry.Tags.Add(t);
                }
            }
            if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                entry.LastUpdated = file.Date.Value;
            if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                entry.LastUpdated = file.CreateDate.Value;
            if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
                entry.LastUpdated = file.LastUpdatedDate.Value;
            if (!string.IsNullOrEmpty(file.Features))
                entry.Description += "\r\n\r\n" + file.Features;
            entry.Tags.AddRange(file.FeatureFlags.ConvertFeatureFlagsToTags());

            List<string> TagsByIpdbNumber = new List<string>();
            if (entry.IpdbId.HasValue)
            {
                var ipdbTags = GetTagsByIpdbNumber(entry.IpdbId.Value);
                foreach (var tag in ipdbTags)
                {
                    var t = NormalizeTag(tag);
                    if (!string.IsNullOrEmpty(t))
                        entry.Tags.Add(t);
                }
            }

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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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

                if (file.Date.HasValue && file.Date.Value.Year != 1) //Start with date
                    entry.LastUpdated = file.Date.Value;
                if (file.CreateDate.HasValue && file.CreateDate.Value.Year != 1) //Start with create date
                    entry.LastUpdated = file.CreateDate.Value;
                if (file.LastUpdatedDate.HasValue && file.LastUpdatedDate.Value.Year != 1) //If last updated is populated move to that instead
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
                    //if (!string.IsNullOrEmpty(entry.Theme))
                    //    list.Add(entry.Theme);
                    //if (!string.IsNullOrEmpty(entry.MPU))
                    //    list.Add(entry.MPU);
                }
            }
            return list;
        }
    }
}
