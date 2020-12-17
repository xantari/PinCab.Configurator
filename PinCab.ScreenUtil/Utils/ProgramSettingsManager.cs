using Newtonsoft.Json;
using PinCab.ScreenUtil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    public interface IProgramSettingsManager
    {
        ProgramSettings LoadSettings(string fileAndPathToSettingFile = "");
        void SaveSettings(ProgramSettings settings, string fileAndPathToSettingFile = "");
    }

    public class ProgramSettingsManager : IProgramSettingsManager
    {
        public ProgramSettingsManager() { }

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

        public void SaveSettings(ProgramSettings settings, string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\DisplaySettings.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;

            using (StreamWriter sw = new StreamWriter(settingsFileNameAndPath, false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                GetJsonSerilizerSettings().Serialize(writer, settings);
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

}
