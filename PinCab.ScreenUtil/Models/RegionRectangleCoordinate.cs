using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil
{
    [Serializable]
    public class RegionRectangleCoordinate
    {
        public RegionRectangleCoordinate() { }

        public RegionRectangleCoordinate(int left, int top, int right, int bottom, string regionLabel, Color regionColor)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            RegionLabel = regionLabel;
            RegionColor = regionColor;
        }


        //The below values are the visible portion of the screen. 
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public string RegionLabel { get; set; }
        public Color RegionColor { get; set; }

        public override string ToString()
        {
            return RegionLabel + " - " + Left.ToString() + "x" + Top.ToString() + " - " + RegionColor.Name;
        }
    }
}
