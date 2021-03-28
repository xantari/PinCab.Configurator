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
    public class DatabaseBrowserSettings
    {
        public DatabaseBrowserSettings()
        {
            BeginDate = new DateTime(1900, 1, 1);
            EndDate = DateTime.Now.EndOfDay();
            TypeFilter = "All";
            DatabaseFilter = "All";
            TagFilter = new List<string>();
            DatabaseGridColumnWidths = new List<int>();
            RelatedGridColumnWidths = new List<int>();
            AddRelatedDatabaseEntryColumnWidths = new List<int>();
        }

        public string SearchTerm { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TypeFilter { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public int AddRelatedWindowHeight { get; set; }
        public int AddRelatedWindowWidth { get; set; }
        public int AddEditWindowHeight { get; set; }
        public int AddEditWindowWidth { get; set; }
        public List<string> TagFilter { get; set; }
        public string DatabaseFilter { get; set; }
        public List<int> DatabaseGridColumnWidths { get; set; }
        public List<int> RelatedGridColumnWidths { get; set; }

        public List<int> AddRelatedDatabaseEntryColumnWidths { get; set; }
    }
}

