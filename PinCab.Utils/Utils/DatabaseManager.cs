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
        public VpUniverseDatabase VpuniverseDatabase { get; private set; }

        public const string ToolName = "Database Manager";

        private List<string> _fileContentsArray { get; set; } = new List<string>();

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
            return true;
        }

        public delegate void ReportProgressDelegate(int percentage);

        public ToolValidationResult RefreshAllDatabases()
        {
            if (!File.Exists(ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpforumdatabase.json") ||
              !File.Exists(ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpsdatabase.json") ||
              !File.Exists(ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpinballdatabase.json") ||
              !File.Exists(ApplicationHelpers.GetApplicationFolder() + "\\Databases\\vpuniversedatabase.json")
            ) //Force a refersh if one or more of the databases disappeared from the file system
            {
                _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow.AddMinutes((_settings.DatabaseUpdateRecheckMinutes * -1) - 1);
            }
            var vpfResult = DownloadDatabase(DatabaseType.VPForums);
            _reportProgress?.Invoke(25);
            var vpuResult = DownloadDatabase(DatabaseType.VPUniverse);
            _reportProgress?.Invoke(50);
            var vpsResult = DownloadDatabase(DatabaseType.VPSSpreadsheet);
            _reportProgress?.Invoke(75);
            var vpResult = DownloadDatabase(DatabaseType.VPinball);
            _reportProgress?.Invoke(100);
            var result = new ToolValidationResult(ToolName);
            result.Messages.AddRange(vpfResult?.Messages);
            result.Messages.AddRange(vpuResult?.Messages);
            result.Messages.AddRange(vpsResult?.Messages);
            result.Messages.AddRange(vpResult?.Messages);
            _settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow;
            _settingManager.SaveSettings(_settings);
            result.Messages.Add(new ValidationMessage("Database refresh completed.", MessageLevel.Information));
            return result;
        }

        public ToolValidationResult DownloadDatabase(DatabaseType type)
        {
            var result = new ToolValidationResult();
            var databaseFolder = ApplicationHelpers.GetApplicationFolder() + "\\Databases";
            if (_settings.LastDatabaseRefreshTimeUtc < DateTime.UtcNow.AddMinutes(_settings.DatabaseUpdateRecheckMinutes * -1))
            {
                if (type == DatabaseType.VPForums)
                {
                    DownloadDatabase(type, _settings.VPForumsDatabaseUrl, databaseFolder + "\\vpforumdatabase.json");
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPForumsDatabaseUrl} to {databaseFolder + "\\vpforumdatabase.json"}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPSSpreadsheet)
                {
                    DownloadDatabase(type, _settings.VPSSpreadsheetUrl, databaseFolder + "\\vpsdatabase.json");
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPSSpreadsheetUrl} to {databaseFolder + "\\vpsdatabase.json"}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPinball)
                {
                    DownloadDatabase(type, _settings.VPinballDatabaseUrl, databaseFolder + "\\vpinballdatabase.json");
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPinballDatabaseUrl} to {databaseFolder + "\\vpinballdatabase.json"}", MessageLevel.Information));
                }
                else if (type == DatabaseType.VPUniverse)
                {
                    DownloadDatabase(type, _settings.VPUniverseDatabaseUrl, databaseFolder + "\\vpuniversedatabase.json");
                    result.Messages.Add(new ValidationMessage($"Downloaded {_settings.VPUniverseDatabaseUrl} to {databaseFolder + "\\vpuniversedatabase.json"}", MessageLevel.Information));
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

        }

        public List<DatabaseBrowserEntry> GetGamesByDatabase(DatabaseType type)
        {
            if (IsValid(type))
            {
                if (type == DatabaseType.VPForums)
                {
                    
                }
                else if (type == DatabaseType.VPinball)
                {

                }
                else if (type == DatabaseType.VPSSpreadsheet)
                {

                }
                else if (type == DatabaseType.VPUniverse)
                {

                }
            }
            return null;
        }
    }

}
