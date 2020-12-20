using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinballY
{
    /// <summary>
    /// Pinball Y Stores the window coordinates where everything is virtual coordinates of the 
    /// left,top,right,bottom corners of the rectangle
    /// </summary>
    public class PinballYWindowRectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}
