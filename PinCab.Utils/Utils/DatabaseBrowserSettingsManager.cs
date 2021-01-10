using Newtonsoft.Json;
using PinCab.Utils.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    public interface IDatabaseBrowserSettingsManager
    {
        DatabaseBrowserSettings LoadSettings(string fileAndPathToSettingFile = "");
        void SaveSettings(DatabaseBrowserSettings settings, string fileAndPathToSettingFile = "");
    }

    public class DatabaseBrowserSettingsManager : IDatabaseBrowserSettingsManager
    {
        public DatabaseBrowserSettingsManager() { }

        public DatabaseBrowserSettings LoadSettings(string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (string.IsNullOrEmpty(fileAndPathToSettingFile))
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\databasebrowserprefs.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;
            if (File.Exists(settingsFileNameAndPath))
            {
                string json = File.ReadAllText(settingsFileNameAndPath);
                var settings = JsonConvert.DeserializeObject<DatabaseBrowserSettings>(json);
                SetDefaultSettingsForMissingOrInvalidSettings(settings);
                return settings;
            }
            return null;
        }

        private void SetDefaultSettingsForMissingOrInvalidSettings(DatabaseBrowserSettings settings)
        {
        }

        public void SaveSettings(DatabaseBrowserSettings settings, string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (string.IsNullOrEmpty(fileAndPathToSettingFile))
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\databasebrowserprefs.json";
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
