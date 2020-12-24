using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class MediaItem
    {
        public MediaItem()
        {
            MediaType = MediaType.Unknown;
            Category = MediaCategory.Unknown;
        }

        public string MediaFullPath { get; set; }
        public MediaType MediaType { get; set; }
        public MediaCategory Category { get; set; }
    }
}
