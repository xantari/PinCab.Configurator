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
        }

        public string SearchTerm { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TypeFilter { get; set; }
        public List<string> TagFilter { get; set; }
        public string DatabaseFilter { get; set; }
        public List<int> DatabaseGridColumnWidths { get; set; }
        public List<int> RelatedGridColumnWidths { get; set; }
    }
}

