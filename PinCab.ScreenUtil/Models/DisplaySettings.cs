using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models
{
    [Serializable]
    public class DisplaySettings
    {
        public DisplaySettings()
        {
            RegionRectangles = new List<RegionRectangle>();
        }

        /// <summary>
        /// Monitor unique display name (\\.\Display1 for example)
        /// </summary>
        public string DisplayName { get; set; }
        public string DisplayLabel { get; set; }
        public List<RegionRectangle> RegionRectangles { get; set; }
    }
}
