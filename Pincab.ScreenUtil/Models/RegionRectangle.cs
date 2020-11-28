using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil
{
    [Serializable]
    public class RegionRectangle
    {
        public RegionRectangle() { }

        public RegionRectangle(int height, int width, int offsetX, int offsetY)
        {
            RegionDisplayHeight = height;
            RegionDisplayWidth = width;
            RegionOffsetX = offsetX;
            RegionOffsetY = offsetY;
        }

        public RegionRectangle(int height, int width, int offsetX, int offsetY, string label, Color color)
        {
            RegionDisplayHeight = height;
            RegionDisplayWidth = width;
            RegionOffsetX = offsetX;
            RegionOffsetY = offsetY;
            RegionLabel = label;
            RegionColor = color;
        }

        //The below values are the visible portion of the screen. 
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
