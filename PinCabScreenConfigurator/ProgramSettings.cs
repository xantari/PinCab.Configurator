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
        }

        public string FFMpegFullPath { get; set; }
        public int RecordTimeSeconds { get; set; }
        public int RecordFramerate { get; set; }
        public string RecordingTempFolderPath { get; set; }

        public List<DisplaySettings> DisplaySettings { get; set; }

        private string GetApplicationFolder()
        {
            string applicationFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return applicationFolder;
        }

        public ProgramSettings LoadSettings(string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = GetApplicationFolder() + "\\DisplaySettings.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;
            string json = File.ReadAllText(settingsFileNameAndPath);
            return JsonConvert.DeserializeObject<ProgramSettings>(json);
        }

        public void SaveSettings(string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = GetApplicationFolder() + "\\DisplaySettings.json";
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

