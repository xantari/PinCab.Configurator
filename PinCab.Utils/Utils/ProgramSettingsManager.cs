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
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\PincabSettings.json";
            else
                settingsFileNameAndPath = fileAndPathToSettingFile;
            if (File.Exists(settingsFileNameAndPath))
            {
                string json = File.ReadAllText(settingsFileNameAndPath);
                var settings = JsonConvert.DeserializeObject<ProgramSettings>(json);
                SetDefaultSettingsForMissingOrInvalidSettings(settings);
                return settings;
            }
            return null;
        }

        private void SetDefaultSettingsForMissingOrInvalidSettings(ProgramSettings settings)
        {
            if (settings.DatabaseUpdateRecheckMinutes == 0)
                settings.DatabaseUpdateRecheckMinutes = 60;
            if (settings.IPDBDatabaseUrl == null)
                settings.IPDBDatabaseUrl = "https://raw.githubusercontent.com/xantari/Ipdb.Database/master/Ipdb.Database/Database/ipdbdatabase.json";
            if (settings.VPForumsDatabaseUrl == null)
                settings.VPForumsDatabaseUrl = "https://raw.githubusercontent.com/xantari/VirtualPinball.Databases/master/Databases/vpforumsdatabase.json";
            if (settings.VPinballDatabaseUrl == null)
                settings.VPinballDatabaseUrl = "https://raw.githubusercontent.com/xantari/VirtualPinball.Databases/master/Databases/vpinballdatabase.json";
            if (settings.VPSSpreadsheetUrl == null)
                settings.VPSSpreadsheetUrl = "https://raw.githubusercontent.com/xantari/VirtualPinball.Databases/master/Databases/vpsdatabase.json";
            if (settings.VPUniverseDatabaseUrl == null)
                settings.VPUniverseDatabaseUrl = "https://raw.githubusercontent.com/xantari/VirtualPinball.Databases/master/Databases/vpuniversedatabase.json";
        }

        public void SaveSettings(ProgramSettings settings, string fileAndPathToSettingFile = "")
        {
            string settingsFileNameAndPath;
            if (fileAndPathToSettingFile == string.Empty)
                settingsFileNameAndPath = ApplicationHelpers.GetApplicationFolder() + "\\PincabSettings.json";
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
