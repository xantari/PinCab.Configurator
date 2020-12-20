using PinCab.Utils.Models.PinballY;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils.PinballY
{
    public class PinballYConfiguration
    {
        private string ToolName = "PinballYConfiguration";
        private string _settingsTxtPath { get; set; }
        private List<PinballYSetting> _settings { get; set; }
        public PinballYConfiguration(string settingsTxtPath)
        {
            _settingsTxtPath = settingsTxtPath;
            _settings = new List<PinballYSetting>();
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(_settingsTxtPath))
                return false;
            if (!File.Exists(_settingsTxtPath))
                return false;
            return true;
        }

        public void LoadSettings()
        {
            if (!IsValid())
                return;
            _settings = GetSettings();
        }

        public PinballYSystem GetSystem(int id)
        {
            if (!IsValid())
                return null;
            if (_settings == null)
                return null;

            var system = new PinballYSystem();
            system.Id = id;
            var settingKeys = Settings.Where(p => p.Type == SettingEnum.Setting && p.ParseSetting().Key.StartsWith($"System{id}")).ToList();
            if (settingKeys.Count == 0)
                return null;
            foreach (var key in settingKeys)
            {
                var kvp = key.ParseSetting();
                if (kvp.Key == $"System{id}")
                    system.Name = kvp.Value;
                if (kvp.Key == $"System{id}.Class")
                    system.Class = kvp.Value;
                if (kvp.Key == $"System{id}.MediaDir")
                    system.MediaDir = kvp.Value;
                if (kvp.Key == $"System{id}.DatabaseDir")
                    system.DatabaseDir = kvp.Value;
                if (kvp.Key == $"System{id}.Exe")
                    system.Exe = kvp.Value;
                if (kvp.Key == $"System{id}.ShowWindow")
                    system.ShowWindow = kvp.Value;
                if (kvp.Key == $"System{id}.Environment")
                    system.Environment = kvp.Value;
                if (kvp.Key == $"System{id}.TablePath")
                    system.TablePath = kvp.Value;
                if (kvp.Key == $"System{id}.Parameters")
                    system.Parameters = kvp.Value;
                if (kvp.Key == $"System{id}.DefExt")
                    system.DefExt = kvp.Value;
                if (kvp.Key == $"System{id}.Enabled")
                    system.Enabled = kvp.Value == "1" ? true : false;
                if (kvp.Key == $"System{id}.RunBeforePre")
                    system.RunBeforePre = kvp.Value;
                if (kvp.Key == $"System{id}.RunBefore")
                    system.RunBefore = kvp.Value;
                if (kvp.Key == $"System{id}.RunAfter")
                    system.RunAfter = kvp.Value;
                if (kvp.Key == $"System{id}.RunAfterPost")
                    system.RunAfterPost = kvp.Value;
                if (kvp.Key == $"System{id}.Process")
                    system.Process = kvp.Value;
                if (kvp.Key == $"System{id}.DOFTitlePrefix")
                    system.DOFTitlePrefix = kvp.Value;
                if (kvp.Key == $"System{id}.TerminateBy")
                    system.TerminateBy = kvp.Value;
                if (kvp.Key == $"System{id}.StartupKeys")
                    system.StartupKeys = kvp.Value;
                if (kvp.Key == $"System{id}.NVRAMPath")
                    system.NVRAMPath = kvp.Value;
                if (kvp.Key == $"System{id}.ShowWindowsWhileRunning")
                    system.ShowWindowsWhileRunning = kvp.Value;
            }
            return system;
        }

        public PinballYWindow GetWindow(WindowType type)
        {
            if (!IsValid())
                return null;
            if (_settings == null)
                return null;

            var window = new PinballYWindow();
            window.WindowName = type.ToString();
            var settingKeys = Settings.Where(p => p.Type == SettingEnum.Setting && p.ParseSetting().Key.StartsWith($"{type}")).ToList();
            if (settingKeys.Count == 0)
                return null;
            foreach (var key in settingKeys)
            {
                var kvp = key.ParseSetting();
                if (kvp.Key == $"{type}.Position")
                    window.Position = kvp.Value;
                if (kvp.Key == $"{type}.Rotation")
                    window.Rotation = Convert.ToInt32(kvp.Value);
                if (kvp.Key == $"{type}.MirrorHorz")
                    window.MirrorHorz = kvp.Value == "1" ? true : false;
                if (kvp.Key == $"{type}.MirrorVert")
                    window.MirrorVert = kvp.Value == "1" ? true : false;
                if (kvp.Key == $"{type}.FullScreen")
                    window.FullScreen = kvp.Value == "1" ? true : false;
                if (kvp.Key == $"{type}.Maximized")
                    window.Maximized = kvp.Value == "1" ? true : false;
                if (kvp.Key == $"{type}.Minimized")
                    window.Minimized = kvp.Value == "1" ? true: false;
                if (kvp.Key == $"{type}.FullScreenPosition")
                    window.FullScreenPosition = kvp.Value;
            }
            return window;
        }

        public void SetWindow(PinballYWindow window)
        {
            if (!IsValid())
                return;
            if (_settings == null)
                return;

            var settingKeys = Settings.Where(p => p.Type == SettingEnum.Setting && p.ParseSetting().Key.StartsWith($"{window.WindowName}")).ToList();
            if (settingKeys.Count == 0)
                return;
            foreach (var key in settingKeys)
            {
                var kvp = key.ParseSetting();
                if (kvp.Key == $"{window.WindowName}.Position")
                    kvp.Value = window.Position;
                if (kvp.Key == $"{window.WindowName}.Rotation")
                    kvp.Value = window.Rotation.ToString();
                if (kvp.Key == $"{window.WindowName}.MirrorHorz")
                    kvp.Value = window.MirrorHorz == true ? "1" : "0";
                if (kvp.Key == $"{window.WindowName}.MirrorVert")
                    kvp.Value = window.MirrorVert == true ? "1" : "0";
                if (kvp.Key == $"{window.WindowName}.FullScreen")
                    kvp.Value = window.FullScreen == true ? "1" : "0";
                if (kvp.Key == $"{window.WindowName}.Maximized")
                    kvp.Value = window.Maximized == true ? "1" : "0";
                if (kvp.Key == $"{window.WindowName}.Minimized")
                    kvp.Value = window.Minimized == true ? "1" : "0";
                if (kvp.Key == $"{window.WindowName}.FullScreenPosition")
                    kvp.Value = window.FullScreenPosition;

                key.SetSetting(kvp);
            }
        }

        public List<PinballYSystem> GetSystems()
        {
            var systems = new List<PinballYSystem>();
            int count = 1;
            while (1 == 1)
            {
                var system = GetSystem(count);
                if (system == null)
                    break;
                else
                    systems.Add(system);

                count++;
            }
            return systems;
        }

        public List<PinballYSetting> Settings { get { return _settings; } }

        private List<PinballYSetting> GetSettings()
        {
            if (!IsValid())
                return null;

            var settings = new List<PinballYSetting>();
            var utf8 = new UTF8Encoding(true);
            using (FileStream fs = File.Open(_settingsTxtPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs, utf8))
                {
                    PinballYSetting setting = null;
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string nextLine = null;
                        if (!sr.EndOfStream)
                            nextLine = sr.ReadLine();

                        var lineType = GetLineType(line);
                        var nextLineType = GetLineType(nextLine);
                        if (setting == null) //Start
                            setting = new PinballYSetting(lineType.Value, string.Empty);

                        setting.Data += line + Environment.NewLine;
                        if (nextLineType.HasValue)
                        {
                            //Comments can span multiple lines, added it to the existing setting if it exists
                            if (nextLineType.Value == setting.Type && setting.Type == SettingEnum.Comment)
                            {
                                setting.Data += nextLine + Environment.NewLine;
                            }
                            else //It's a new value (blank line or a key/value pair)
                            {
                                settings.Add(setting);
                                setting = new PinballYSetting(nextLineType.Value, nextLine + Environment.NewLine);
                                if (nextLineType.Value != SettingEnum.Comment)
                                {
                                    settings.Add(setting);
                                    setting = null;
                                }
                            }
                        }
                        else //End of file
                        {
                            settings.Add(setting);
                        }
                    }
                }
            }
            return settings;
        }

        public void SaveSettings(bool performBackup = true)
        {
            if (!IsValid())
                return;

            if (performBackup)
            {
                //Copy current file as backup
                var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\PinballY\\";
                var fileInfo = new FileInfo(_settingsTxtPath);
                Directory.CreateDirectory(currentFolder);
                string filePath = $"{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}";
                File.Copy(_settingsTxtPath, currentFolder + filePath);

                Log.Information("{ToolName}: Wrote setting backup: {location}", ToolName, filePath);
            }

            var utf8 = new UTF8Encoding(true);
            using (FileStream fs = File.Open(_settingsTxtPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, utf8))
                {
                    foreach (var setting in Settings)
                    {
                        if (setting.Type == SettingEnum.BlankLine)
                            sw.Write(Environment.NewLine);
                        else
                            sw.Write(setting.Data);
                    }
                }
            }
        }

        private SettingEnum? GetLineType(string data)
        {
            if (data == null)
                return null;
            if (data.StartsWith("#"))
                return SettingEnum.Comment;
            else if (data?.Trim() == string.Empty)
                return SettingEnum.BlankLine;
            return SettingEnum.Setting;
        }
    }
}
