using IniParser.Model;
using PinCab.Utils.Utils.PinballX;
using PinCab.Utils.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinballX
{
    public class PinballXSystem
    {
        public readonly string DefaultExecutableLabel = "<default>";
        // from pinballx.ini
        public string Name { get; set; }

        public string StatsSectionName { get {
                return Name.Replace(" ", "");
        } }
        public bool Enabled { get; set; }
        public string WorkingPath { get; set; }
        public string TablePath { get; set; }
        public string Executable { get; set; }
        public string Parameters { get; set; }
        /// <summary>
        /// A list of database files (with path) of this system.
        /// </summary>
        public List<string> DatabaseFiles { get; private set; } = new List<string>();

        /// <summary>
        /// A list of executables used in this system. Note that null string equals default executable.
        /// </summary>
        public List<string> Executables { get; private set; } = new List<string>();

        public string DatabasePath { get; private set; }
        public string MediaPath { get; private set; }

        public string PinballXIniFilePath { get; set; }
        public string PinballXFolder { get; set; }
        public Platform Type { get; set; }
        /// <summary>
        /// Games database, string is the database file string
        /// </summary>
        public Dictionary<string, List<PinballXGame>> Games { get; } = new Dictionary<string, List<PinballXGame>>();

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
        /// <param name="platform">If passed in will use that platform type. If null, will detect platform from SystemType flag if present, otherwise it is an unknown platform</param>
        public PinballXSystem(string pinballXIniFilePath, string name, KeyDataCollection data, Platform? platform)
        {
            PinballXIniFilePath = pinballXIniFilePath;
            Name = name;
            SetByData(data, platform);
        }

        public List<DatabaseFileViewModel> GetDatabaseFileViewModel()
        {
            var list = new List<DatabaseFileViewModel>();
            foreach (var database in DatabaseFiles)
            {
                list.Add(new DatabaseFileViewModel() { DatabaseFile = database, DatabaseFilePathShort = database.Replace(DatabasePath.Replace(Name, string.Empty), string.Empty) });
            }
            return list;
        }

        private void SetByData(KeyDataCollection data, Platform? platform)
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
            if (!platform.HasValue)
            {
                var systemType = data["SystemType"];
                if ("0".Equals(systemType))
                    Type = Platform.Custom;
                else if ("1".Equals(systemType))
                    Type = Platform.VP;
                else if ("2".Equals(systemType))
                    Type = Platform.FP;
                else
                    Type = Platform.Undefined;
            }
            else
                Type = platform.Value;

            DatabasePath = Path.Combine(PinballXFolder, "Databases", Name);
            MediaPath = Path.Combine(PinballXFolder, "Media", Name);

            DatabaseFiles = GetDatabaseFiles();
        }

        private List<string> GetDatabaseFiles()
        {
            return Directory
                .GetFiles(DatabasePath)
                .Where(filePath => ".xml".Equals(Path.GetExtension(filePath), StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Returns false if not a valid system (stray/empty entries in pinballx.ini)
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            if (string.IsNullOrEmpty(Executable))
                return false;
            if (Type == Platform.Undefined)
                return false;
            return true;
        }
    }
}
