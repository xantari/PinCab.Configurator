using Newtonsoft.Json;
using PinCab.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    [Serializable]
    public class ProgramSettings
    {
        public ProgramSettings()
        {
            DisplaySettings = new List<DisplaySettings>();
            DatabaseUpdateRecheckMinutes = 60;
            LastDatabaseRefreshTimeUtc = new DateTime(1900, 1, 1);
            DatabaseBrowserSettings = new DatabaseBrowserSettings();
            RecordingSettings = new RecordingSettings();
            Databases = new List<ContentDatabase>();
        }

        public string PinupPopperSqlLiteDbPath { get; set; }
        public string PinballYSettingsPath { get; set; }
        public string PinballXIniPath { get; set; }
        public string B2SScreenResPath { get; set; }
        public string PinupPlayerPath { get; set; }
        public string FutureDMDIniPath { get; set; }
        public string DMDDeviceIniPath { get; set; }
        public string PRocUserSettingsPath { get; set; }

        public List<DisplaySettings> DisplaySettings { get; set; }

        public string LastSelectedFrontEnd { get; set; }
        public string LastSelectedDatabaseFile { get; set; }

        public int DatabaseUpdateRecheckMinutes { get; set; }
        public DateTime LastDatabaseRefreshTimeUtc { get; set; }

        public DatabaseBrowserSettings DatabaseBrowserSettings { get; set; }
        public RecordingSettings RecordingSettings { get; set; }
        public List<ContentDatabase> Databases { get; set; }

        public bool PinupPopperExists()
        {
            if (string.IsNullOrWhiteSpace(PinupPopperSqlLiteDbPath))
                return false;
            if (!File.Exists(PinupPopperSqlLiteDbPath))
                return false;
            return true;
        }

        public bool PinballXExists()
        {
            if (string.IsNullOrWhiteSpace(PinballXIniPath))
                return false;
            if (!File.Exists(PinballXIniPath))
                return false;
            return true;
        }

        public bool PinballYExists()
        {
            if (string.IsNullOrWhiteSpace(PinballYSettingsPath))
                return false;
            if (!File.Exists(PinballYSettingsPath))
                return false;
            return true;
        }
    }
}

