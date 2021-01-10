using PinCab.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class DatabaseBrowserEntry
    {
        public DatabaseBrowserEntry()
        {
            RelatedEntries = new List<DatabaseBrowserEntry>();
            Tags = new List<string>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChangeLog { get; set; }
        public string Authors { get; set; }
        public List<string> Tags { get; set; }
        public string Url { get; set; }
        public int? IpdbId { get; set; }
        public string Version { get; set; }
        public DateTime LastUpdated { get; set; }

        public string TypeString
        {
            get
            {
                return Type.GetEnumDescription();
            }
        }
        public DatabaseEntryType Type { get; set; }
        public string DatabaseTypeString
        {
            get
            {
                return DatabaseType.GetEnumDescription();
            }
        }
        public DatabaseType DatabaseType { get; set; }

        public string DatabaseTagsString
        {
            get
            {
                return string.Join(", ", Tags.ToArray());
            }
        }

        public List<DatabaseBrowserEntry> RelatedEntries { get; set; }
    }
}
