﻿using Newtonsoft.Json;
using PinCab.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPinball.Database.Models;

namespace PinCab.Utils.Models
{
    public class DatabaseBrowserEntry
    {
        public DatabaseBrowserEntry()
        {
            RelatedEntries = new HashSet<DatabaseBrowserEntry>();
            Tags = new HashSet<string>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChangeLog { get; set; }
        public string Authors { get; set; }
        public HashSet<string> Tags { get; set; }
        public string Url { get; set; }
        public int? IpdbId { get; set; }
        public string Version { get; set; }
        public string DatabaseName { get; set; }
        public DateTime LastUpdated { get; set; }

        public string TypeString
        {
            get
            {
                return Type.GetEnumDescription();
            }
        }
        public MajorCategory Type { get; set; }
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

        public HashSet<DatabaseBrowserEntry> RelatedEntries { get; set; }

        public Uri GetUri()
        {
            Uri uriResult;
            bool result = Uri.TryCreate(Url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
                return uriResult;
            else
                return null;
        }
    }
}
