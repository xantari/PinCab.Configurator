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
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VirtualPinball.Database.Models;

namespace PinCab.Utils.Utils
{

    public class DatabaseManager
    {
        private ProgramSettings _settings { get; set; }
        private ProgramSettingsManager _settingManager = new ProgramSettingsManager();

        public Dictionary<string, PinballDatabase> Databases { get; private set; }
        public IpdbDatabase IpdbDatabase { get; private set; }

        public List<DatabaseBrowserEntry> Entries { get; private set; }

        public const string ToolName = "Database Manager";

        //private List<string> _fileContentsArray { get; set; } = new List<string>();
        private string databaseFolder = ApplicationHelpers.GetApplicationFolder() + "\\Databases";
        private string preprocessedDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\preprocesseddatabase.json";
        //TODO: For eventual caching of preprocessed database tags
        //private string tagDatabasePath = ApplicationHelpers.GetApplicationFolder() + "\\Databases\\tagdatabase.json";

        private ReportProgressDelegate _reportProgress;
        public ProgramSettings Settings { get { return _settings; } }

        public string PreprocessedDatabasePath { get { return preprocessedDatabasePath; } }

        public DatabaseManager(ReportProgressDelegate reportProgress = null)
        {
            _settings = _settingManager.LoadSettings();
            _reportProgress = reportProgress;
            Entries = new List<DatabaseBrowserEntry>();
            Databases = new Dictionary<string, PinballDatabase>();
        }

        public bool IsValid(ContentDatabase database)
        {
            if (string.IsNullOrEmpty(database.Url))
            {
                Log.Information("{toolname}: Missing URL on {name}.", ToolName, database.Name);
                return false;
            }
            return true;
        }

        public delegate void ReportProgressDelegate(int percentage);

        public ContentDatabase GetIpdbContentDatabase()
        {
            return _settings.Databases.FirstOrDefault(c => c.Type == DatabaseType.IPDB);
        }

        public ToolResult RefreshAllDatabases()
        {
            foreach (var database in _settings.Databases)
            {
                if (!DatabaseWorkFileExistsOnFilesystem(database)) //Force a refersh if one or more of the databases disappeared from the file system
                {
                    _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow.AddMinutes((_settings.DatabaseUpdateRecheckMinutes * -1) - 1);
                }
            }

            var result = new ToolResult(ToolName);
            bool downloadedAtleastOneDatabase = false;
            for (int i = 0; i < _settings.Databases.Count; i++)
            {
                _reportProgress?.Invoke((int)(i / (decimal)_settings.Databases.Count) * 100);
                var databaseResult = DownloadDatabase(_settings.Databases[i]);
                if ((bool)databaseResult.Result)
                    downloadedAtleastOneDatabase = true;
                result.Messages.AddRange(databaseResult?.Messages);
            }

            _reportProgress?.Invoke(100);

            if (downloadedAtleastOneDatabase)
            {
                _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow; //Only bump the date if we re-downloaded something
                result.Result = true;
                _settingManager.SaveSettings(_settings);
            }
            else
            {
                result.Result = false; //We didn't re-download anything
            }
            result.Messages.Add(new ValidationMessage("Database refresh completed.", MessageLevel.Information));
            return result;
        }

        public void SanitizeAllDatabaseEntries(PinballDatabase database)
        {
            foreach (var file in database.Entries)
                SanitizeEntry(file);
        }

        public DatabaseEntry SanitizeEntry(DatabaseEntry entry)
        {
            if (entry.ScreenshotUrls?.Count == 0)
                entry.ScreenshotUrls = null;
            if (entry.RelatedEntries?.Count == 0)
                entry.RelatedEntries = null;
            if (entry.Tags?.Count == 0)
                entry.Tags = null;
            if (entry.AdditionalInfoUrls?.Count == 0)
                entry.AdditionalInfoUrls = null;
            if (entry.RelatedEntries != null)
                entry.RelatedEntries = entry.RelatedEntries.Distinct().OrderBy(c => c).ToList();

            if (string.IsNullOrEmpty(entry.Version))
                entry.Version = null;
            if (string.IsNullOrEmpty(entry.Manufacturer))
                entry.Manufacturer = null;
            if (string.IsNullOrEmpty(entry.Authors))
                entry.Authors = null;
            if (string.IsNullOrEmpty(entry.Features))
                entry.Features = null;
            if (string.IsNullOrEmpty(entry.Theme))
                entry.Theme = null;
            if (string.IsNullOrEmpty(entry.Url))
                entry.Url = null;
            if (string.IsNullOrEmpty(entry.ChangeLog))
                entry.ChangeLog = null;
            if (string.IsNullOrEmpty(entry.Description))
                entry.Description = null;
            return entry;
        }

        public ToolResult DownloadDatabase(ContentDatabase database, bool forceDownload = false)
        {
            var result = new ToolResult();

            if (_settings.LastDatabaseRefreshTimeUtc <
                DateTime.UtcNow.AddMinutes(_settings.DatabaseUpdateRecheckMinutes * -1)
                || forceDownload)
            {
                bool success = DownloadDatabaseToFilesystem(database, GetFilesystemWorkPath(database));
                if (success)
                    result.Messages.Add(new ValidationMessage($"Downloaded {database.Url} to {GetFilesystemWorkPath(database)}", MessageLevel.Information));
                else
                    result.Messages.Add(new ValidationMessage($"Unable to download {database.Url} to {GetFilesystemWorkPath(database)}", MessageLevel.Error));

                result.Result = true; //Inidicate we downloaded something
            }
            else
            {
                var nextRefreshTime = _settings.LastDatabaseRefreshTimeUtc.AddMinutes(_settings.DatabaseUpdateRecheckMinutes);
                result.Messages.Add(new ValidationMessage($"Not at recheck minutes threshold. Next Refresh: {nextRefreshTime}. Database: {database.Name}", MessageLevel.Information));
                Log.Information("{toolname}: Not at recheck minutes threshold. Next Refresh: {date}.", ToolName, nextRefreshTime);
                result.Result = false; //Indicate we did NOT downloaded something
            }
            return result;
        }

        private bool DownloadDatabaseToFilesystem(ContentDatabase database, string downloadPath)
        {
            //If it's not a url, just consider it already downloaded
            if (File.Exists(database.Url))
                return true;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    if (database.Url.ToLower().Contains("github") && !string.IsNullOrEmpty(database.AccessToken))
                    {
                        wc.Headers.Add("Authorization", "token " + database.AccessToken);
                    }
                    //wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    var url = new Uri(database.Url);
                    wc.DownloadFile(url, downloadPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error downloading file: {file}", database.Url);
            }
            return false; //failure
        }

        public void LoadAllDatabases()
        {
            Databases = new Dictionary<string, PinballDatabase>();
            foreach (var database in _settings.Databases)
                LoadDatabase(database);
        }

        public void LoadDatabase(ContentDatabase database)
        {
            if (File.Exists(GetFilesystemWorkPath(database)) && database.Type == DatabaseType.PinballDatabase)
            {
                var db = JsonConvert.DeserializeObject<PinballDatabase>(File.ReadAllText(GetFilesystemWorkPath(database)), GetJsonSerilizerSettings());
                SanitizeAllDatabaseEntries(db);
                Databases.Add(database.Name, db);
            }
            else if (File.Exists(GetFilesystemWorkPath(database)) && database.Type == DatabaseType.IPDB)
            {
                IpdbDatabase = JsonConvert.DeserializeObject<IpdbDatabase>(File.ReadAllText(GetFilesystemWorkPath(database)), GetJsonSerilizerSettings());
            }
        }

        /// <summary>
        /// Checks if the mirrored database exists on the file system. We download from a URL first. 
        /// Then save to local databases folder.
        /// If it's a pointer to a local file already, we still mirror the file and end up updated it in both the mirroed location
        /// and the official location
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public bool DatabaseWorkFileExistsOnFilesystem(ContentDatabase database)
        {
            if (!string.IsNullOrEmpty(database.Url))
            {
                string fullFilePath = $"{databaseFolder}\\{database.Name}.json";
                if (File.Exists(fullFilePath))
                    return true;
                //if (File.Exists(database.Url)) //If this is a local file system path instead of a url get the file path
                //{
                //    var fi = new FileInfo(database.Url);
                //    fullFilePath = $"{databaseFolder}\\{fi.Name}";
                //    if (File.Exists(fullFilePath))
                //        return true;
                //}
                //else //Url based paths
                //{
                //    var uri = new Uri(database.Url);
                //    fullFilePath = $"{databaseFolder}\\{uri.Segments.Last()}";
                //    if (File.Exists(fullFilePath))
                //        return true;
                //}
            }
            return false;
        }

        public string GetFilesystemWorkPath(ContentDatabase database)
        {
            if (!string.IsNullOrEmpty(database.Url))
            {
                return $"{databaseFolder}\\{database.Name}.json";
                //if (File.Exists(database.Url)) //If this is a local file system path instead of a url get the file path
                //{
                //    var fi = new FileInfo(database.Url);
                //    return $"{databaseFolder}\\{fi.Name}";
                //}
                //else //Url based path
                //{
                //    var uri = new Uri(database.Url);
                //    return $"{databaseFolder}\\{uri.Segments.Last()}";
                //}
            }
            return null;
        }

        public List<DatabaseBrowserEntry> GetAllEntries(bool forceReload)
        {
            var entries = new List<DatabaseBrowserEntry>();
            //Ensure a local cached copy exists, otherwise force a reload
            if (!File.Exists(preprocessedDatabasePath))
                forceReload = true;

            if (forceReload)
            {
                for (int i = 0; i < _settings.Databases.Count; i++)
                {
                    _reportProgress?.Invoke((i / _settings.Databases.Count) * 100);
                    entries.AddRange(GetEntrysByDatabase(_settings.Databases[i], forceReload));
                }
                _reportProgress?.Invoke(100);
                Entries = entries;
                //Write the preprocessed database so next load is faster
                SaveDatabaseCache(entries, preprocessedDatabasePath);
            }
            else
            {
                _reportProgress?.Invoke(10);
                entries = JsonConvert.DeserializeObject<List<DatabaseBrowserEntry>>(File.ReadAllText(preprocessedDatabasePath), GetJsonSerilizerSettings());
                Entries = entries;
                Log.Information("{toolname}: Loaded preprocessed database.", ToolName, preprocessedDatabasePath);
                _reportProgress?.Invoke(100);
            }

            return entries;
        }

        public List<ValidationMessage> GetDatabaseVersionMessages()
        {
            var entries = new List<ValidationMessage>();
            if (Databases != null)
            {
                foreach (var db in Databases)
                {
                    entries.Add(new ValidationMessage()
                    {
                        Level = MessageLevel.Information,
                        Message = db.Key + " Database Last Updated (UTC): " + db.Value.LastRefreshDateUtc + " Local: " + db.Value.LastRefreshDateUtc.ToLocalTime()
                    });
                }
            }

            return entries;
        }

        public List<DatabaseBrowserEntry> GetEntrysByDatabase(ContentDatabase database, bool forceReload)
        {
            List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();

            if (IsValid(database) && forceReload)
            {
                if (database.Type == DatabaseType.PinballDatabase)
                {
                    var loadedDb = Databases.ContainsKey(database.Name);
                    if (!loadedDb)
                    {
                        Log.Warning("{tool}: {dbname} database not loaded. Did you load the databse first?", ToolName, database.Name);
                        return entries;
                    }
                    entries.AddRange(GetDatabaseBrowserEntries(database));
                }

                return entries;
            }
            //We return the preprocessed database if it exists and we haven't reached a condition where we need to refresh the 
            //database (reached refresh timeframe or the preprocessed database doesn't exist yet)
            else if (IsValid(database) && !forceReload)
            {
                var loadedEntries = JsonConvert.DeserializeObject<List<DatabaseBrowserEntry>>(File.ReadAllText(preprocessedDatabasePath), GetJsonSerilizerSettings());
                return loadedEntries.Where(p => p.DatabaseType == DatabaseType.PinballDatabase
                    && p.DatabaseName == database.Name).ToList();
            }
            return null;
        }

        private HashSet<DatabaseBrowserEntry> GetDatabaseBrowserEntries(ContentDatabase database)
        {
            HashSet<DatabaseBrowserEntry> entries = new HashSet<DatabaseBrowserEntry>();
            foreach (var databaseEntry in Databases[database.Name].Entries)
            {
                var entry = GetDatabaseBrowserEntry(database, databaseEntry);
                if (IsValidBrowserEntry(entry))
                    entries.Add(entry);
                else
                    Log.Information("{tool}: Skipped adding {entry} because it didn't pass the data check.", ToolName, entry.Title);

                //Add the related entries
                if (databaseEntry.RelatedEntries != null)
                {
                    foreach (var relatedEntry in databaseEntry.RelatedEntries)
                    {
                        var relatedContentEntry = Databases[database.Name].Entries.FirstOrDefault(c => c.Id == relatedEntry);
                        var newEntry = GetDatabaseBrowserEntry(database, relatedContentEntry);
                        if (IsValidBrowserEntry(newEntry))
                        {
                            entry.RelatedEntries.Add(newEntry);
                            entry.Tags.UnionWith(newEntry.Tags);
                        }
                        else
                            Log.Information("{tool}: Skipped related entry adding {entry} because it didn't pass the data check.", ToolName, relatedContentEntry.Title);
                    }
                }
            }

            //Rescan the related entries and fill in missing tags that we were able to find for the URL in a different
            //area of the database

            return entries;
        }

        private bool IsValidBrowserEntry(DatabaseBrowserEntry entry)
        {
            if (string.IsNullOrWhiteSpace(entry.Url))
                return false;
            return true;
        }

        public HashSet<string> GetAllTags(List<DatabaseBrowserEntry> entries, bool reportProgress = true)
        {
            var tags = new HashSet<string>();
            if (reportProgress)
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
                    if (itm != null)
                        tags.Add(itm);
            }
            if (reportProgress)
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

        public DatabaseBrowserEntry GetDatabaseBrowserEntry(ContentDatabase database, DatabaseEntry file)
        {
            var entry = new DatabaseBrowserEntry();
            entry = MapDatabaseEntryToBrowserEntry(database, file, entry);
            return entry;
        }

        public DatabaseBrowserEntry MapDatabaseEntryToBrowserEntry(ContentDatabase database, DatabaseEntry file, DatabaseBrowserEntry entry)
        {
            entry.Id = file.Id;
            entry.Authors = file.Authors;
            entry.ChangeLog = string.IsNullOrEmpty(file.ChangeLog) ? string.Empty : file.ChangeLog;
            entry.DatabaseType = DatabaseType.PinballDatabase;
            entry.Description = string.IsNullOrEmpty(file.Description) ? string.Empty : file.Description;
            entry.IpdbId = file.IpdbNumber;
            entry.Title = file.Title;
            entry.Type = file.MajorCategory;
            entry.Url = file.Url;
            entry.Version = file.Version;
            entry.Tags = file.Tags?.ToHashSet<string>();
            entry.DatabaseName = database.Name;
            entry.LastUpdated = file.LastModifiedDateUtc.HasValue ? file.LastModifiedDateUtc.Value : new DateTime(1900, 1, 1);

            if (string.IsNullOrEmpty(file.Title) && !string.IsNullOrEmpty(file.FileName))
            {
                entry.Title = file.FileName;
            }

            if (string.IsNullOrEmpty(entry.Title))
                entry.Title = string.Empty;

            if (!string.IsNullOrEmpty(file.ChangeLog))
                entry.Description += "\r\n\r\nChange Log:\r\n" + file.ChangeLog;

            if (!string.IsNullOrEmpty(file.Features))
                entry.Description += "\r\n\r\nFeatures:\r\n" + file.Features;

            var tableInfoTags = file.ConvertTableInfoToTags();
            if (entry.Tags == null)
                entry.Tags = new HashSet<string>();
            entry.Tags.UnionWith(tableInfoTags);

            List<string> TagsByIpdbNumber = GetIpdbTags(entry);
            entry.Tags.UnionWith(TagsByIpdbNumber);
            //entry.Tags = entry.Tags.NormalizeTagList();
            return entry;
        }

        private List<string> GetIpdbTags(DatabaseBrowserEntry entry)
        {
            var list = new List<string>();
            if (entry.IpdbId.HasValue)
            {
                var ipdbTags = GetTagsByIpdbNumber(entry.IpdbId.Value);
                list.AddRange(ipdbTags);
            }

            return list.NormalizeTagList();
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

        public void SaveDatabaseCache<T>(T database, string fileAndPathToDatabase)
        {
            Log.Warning("{tool}: Preprocessed database cache saved to {path}", ToolName, fileAndPathToDatabase);
            using (StreamWriter sw = new StreamWriter(fileAndPathToDatabase, false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                GetJsonSerilizer().Serialize(writer, database);
            }
        }

        private JsonSerializer GetJsonSerilizer()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            //serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            return serializer;
        }

        private JsonSerializerSettings GetJsonSerilizerSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            return settings;
        }
    }
}
