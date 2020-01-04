using EDIDParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDisplayAPI;

namespace Pincab.ScreenUtil
{
    [Serializable]
    public class DisplayDetail
    {
        public DisplayDetail() { }
        /// <summary>
        /// Classic built in .NET Display info (very minimal info)
        /// </summary>
        //public Screen Screen { get; set; }
        /// <summary>
        /// WindowsDisplayApi Nuget package, much more complete info. Lots of options with this nuget
        /// </summary>
        public Display Display { get; set; }
        /// <summary>
        /// Connected Display EDID info. Syou can give the actual info about the connected display (manufacturer, serial #, etc) in drop down lists and other areas rather
        /// then just DISPLAY 1, DISPLAY 2, which isn't as helpful to end user
        /// </summary>
        public EDID EdidInfo { get; set; }

        public string DisplayLabel { get; set; }

        //The below values are the visible portion of the screen. This is defined in the front end (PinballX) ini depending on your screen.
        //TODO: Load from PinballX INI
        public int OffsetY { get; set; }
        public int OffsetX { get; set; }
        public int VisibleDisplayWidth { get; set; }
        public int VisibleDisplayHeight { get; set; }

        public override string ToString()
        {
            string temp = Display?.ToString();
            if (EdidInfo != null) 
                temp += " - " + EdidInfo.GetDisplayEdidManufacturerAndSerial();
            if (!string.IsNullOrEmpty(DisplayLabel))
                temp += " - " + DisplayLabel;
            return temp;
        }
    }
}
