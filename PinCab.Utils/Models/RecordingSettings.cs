using FluentDateTime;
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
    public class RecordingSettings
    {
        public RecordingSettings()
        {
            DatabaseGridColumnWidths = new List<int>();
            RecordTimeSeconds = 30;
            RecordFramerate = 30;
            RecordTimeStartupDelaySeconds = 30;
            LastSelectedRecordingMethod = "OBS Studio"; //OBS Studio or FFMpeg
            PlayfieldRecordMode = BackglassRecordMode = DMDRecordMode = TopperRecordMode = FullDMDRecordMode = ApronRecordMode  = "Record Only if Missing";
        }

        public string LastSelectedRecordingMethod { get; set; }
        public string FFMpegPath { get; set; }
        public string ObsFullPath { get; set; }
        public string ObsConfigPath { get; set; }
        public int RecordTimeStartupDelaySeconds { get; set; }
        public int RecordTimeSeconds { get; set; }
        public int RecordFramerate { get; set; }
        public string RecordingTempFolderPath { get; set; }

        public string PlayfieldRecordMode { get; set; } //Do Not Record, Record Only if Missing, Record Always
        public string BackglassRecordMode { get; set; }
        public string DMDRecordMode { get; set; }
        public string TopperRecordMode { get; set; }
        public string FullDMDRecordMode { get; set; }
        public string ApronRecordMode { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public List<int> DatabaseGridColumnWidths { get; set; }
    }
}

