using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    [Serializable]
    public class ContentDatabase
    {
        public ContentDatabase() { }
        public DatabaseType Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }

        public bool IsUrl()
        {
            Uri uri;
            bool result = Uri.TryCreate(Url, UriKind.Absolute, out uri);
            if (result)
            {
                if (uri.Scheme == "file")
                    return false;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Name + " (" + (IsUrl() ? "Github)" : "File System)");
        }
    }
}
