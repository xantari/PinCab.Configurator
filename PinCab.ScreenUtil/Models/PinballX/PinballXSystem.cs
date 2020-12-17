using IniParser.Model;
using PinCab.ScreenUtil.Utils.PinballX;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models.PinballX
{
    public class PinballXSystem
    {
        public const string DefaultExecutableLabel = "<default>";
        // from pinballx.ini
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string WorkingPath { get; set; }
        public string TablePath { get; set; }
        public string Executable { get; set; }
        public string Parameters { get; set; }
        /// <summary>
        /// A list of database files (without path) of this system.
        /// </summary>
        public List<string> DatabaseFiles { get; } = new List<string>();

        /// <summary>
        /// A list of executables used in this system. Note that null string equals default executable.
        /// </summary>
        public List<string> Executables { get; } = new List<string>();

        public string DatabasePath { get; private set; }
        public string MediaPath { get; private set; }

        public string PinballXIniFilePath { get; set; }
        public string PinballXFolder { get; set; }
        public Platform Type { get; set; }

        public PinballXSystem(string pinballXIniFilePath)
        {
            PinballXIniFilePath = pinballXIniFilePath;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pinballXIniFilePath"></param>
        /// <param name="name">Pass in NULL if a custom system</param>
        /// <param name="data"></param>
        public PinballXSystem(string pinballXIniFilePath, string name,  KeyDataCollection data)
        {
            PinballXIniFilePath = pinballXIniFilePath;
            Name = name;
            SetByData(data);
        }

        private void SetByData(KeyDataCollection data)
        {
            DirectoryInfo info = new DirectoryInfo(PinballXIniFilePath);
            PinballXFolder = info.Parent.Parent.FullName;

            Enabled = "true".Equals(data["Enabled"], StringComparison.InvariantCultureIgnoreCase);
            WorkingPath = data["WorkingPath"];
            TablePath = data["TablePath"];
            Executable = data["Executable"];
            Parameters = data["Parameters"];
            if (Name == null) //Custom system, not the predefined Future Pinball or Visual Pinball systems
                Name = data["Name"];
            var systemType = data["SystemType"];
            if ("0".Equals(systemType))
            {
                Type = Platform.Custom;
            }
            else if ("1".Equals(systemType))
            {
                Type = Platform.VP;
            }
            else if ("2".Equals(systemType))
            {
                Type = Platform.FP;
            }

            DatabasePath = Path.Combine(PinballXFolder, "Databases", Name);
            MediaPath = Path.Combine(PinballXFolder, "Media", Name);
        }
    }
}
