using Newtonsoft.Json;
using PinCab.ScreenUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models
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

