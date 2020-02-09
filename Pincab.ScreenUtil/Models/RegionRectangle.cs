using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil
{
    [Serializable]
    public class RegionRectangle
    {
        public RegionRectangle() { }

        //The below values are the visible portion of the screen. This is defined in the front end (PinballX) ini depending on your screen.
        //TODO: Load from PinballX INI
        public int RegionOffsetY { get; set; }
        public int RegionOffsetX { get; set; }
        public int RegionDisplayWidth { get; set; }
        public int RegionDisplayHeight { get; set; }
        public string RegionLabel { get; set; }
        public Color RegionColor { get; set; }

        public override string ToString()
        {
            return RegionLabel + " - " + RegionDisplayWidth.ToString() + "x" + RegionDisplayHeight.ToString() + " - " + RegionColor.Name;
        }
    }
}
