using Newtonsoft.Json;
using Pincab.ScreenUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCabScreenConfigurator
{
    [Serializable]
    public class ProgramSettings
    {
        public ProgramSettings()
        {
            DisplaySettings = new List<DisplaySettings>();
            RecordTimeSeconds = 30;
            RecordFramerate = 30;
        }

        public string FFMpegFullPath { get; set; }
        public int RecordTimeSeconds { get; set; }
        public int RecordFramerate { get; set; }
        public string RecordingTempFolderPath { get; set; }

        public string PinupPopperSqlLiteDbPath { get; set; }
        public string PinballYSettingsPath { get; set; }
        public string PinballXIniPath { get; set; }
        public string B2SScreenResPath { get; set; }
        public string PinupPlayerPath { get; set; }
        public string FutureDMDIniPath { get; set; }
        public string DMDDeviceIniPath { get; set; }
        public string PRocUserSettingsPath { get; set; }

        public List<DisplaySettings> DisplaySettings { get; set; }

        public ProgramSettings LoadSettings(string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\DisplaySettings.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;
            if (File.Exists(settingsFileNameAndPath))
            {
                string json = File.ReadAllText(settingsFileNameAndPath);
                return JsonConvert.DeserializeObject<ProgramSettings>(json);
            }
            return null;
        }

        public void SaveSettings(string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\DisplaySettings.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;

            using (StreamWriter sw = new StreamWriter(settingsFileNameAndPath, false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                GetJsonSerilizerSettings().Serialize(writer, this);
            }
        }

        private JsonSerializer GetJsonSerilizerSettings()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            return serializer;
        }
    }

    [Serializable]
    public class DisplaySettings
    {
        public DisplaySettings()
        {
            RegionRectangles = new List<RegionRectangle>();
        }

        /// <summary>
        /// Monitor unique display name (\\.\Display1 for example)
        /// </summary>
        public string DisplayName { get; set; }
        public string DisplayLabel { get; set; }
        public List<RegionRectangle> RegionRectangles { get; set; }
    }
}

