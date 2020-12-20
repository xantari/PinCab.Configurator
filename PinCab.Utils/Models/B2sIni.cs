using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    /// <summary>
    /// Model that represents the B2sIni file and all 12 of it's lines
    /// </summary>
    public class B2sIni
    {
        /// <summary>
        /// X Resolution / Width, Line 1
        /// </summary>
        public int PlayfieldWidth { get; set; }
        /// <summary>
        /// Y Resolution / Height, Line 2
        /// </summary>
        public int PlayfieldHeight { get; set; }
        /// <summary>
        /// Backglass screen X resolution(width), Line 3
        /// </summary>
        public int BackglassWidth { get; set; }
        /// <summary>
        /// Backglass screen Y resolution(height), Line 4
        /// </summary>
        public int BackglassHeight { get; set; }
        /// <summary>
        /// Display number for the backglass, Line 5
        /// </summary>
        public int BackglassDisplayNumber { get; set; }
        /// <summary>
        /// X offset for the backglass on the selected display(normally left at 0), Line 6
        /// </summary>
        public int BackglassXOffset { get; set; }
        /// <summary>
        /// Y offset for the backglass on the selected display(normally left at 0), Line 7
        /// </summary>
        public int BackglassYOffset { get; set; }
        /// <summary>
        /// Width of the DMD area in pixels, Line 8
        /// </summary>
        public int DMDWidth { get; set; }
        /// <summary>
        /// Height of the DMD area in pixels, Line 9
        /// </summary>
        public int DMDHeight { get; set; }
        /// <summary>
        /// X position of the DMD area relative to the upper left corner of the backglass screen, Line 10
        /// </summary>
        public int DMDXOffset { get; set; }
        /// <summary>
        /// Y position of the DMD area relative to the upper left corner of the backglass screen, Line 11
        /// </summary>
        public int DMDYOffset { get; set; }
        /// <summary>
        /// 0 or 1, flips the lED display upside down, used in P2K style cabs, Line 12
        /// </summary>
        public int YFlip { get; set; }

        /// <summary>
        /// Gets the order list of INI values to place into the B2S file
        /// </summary>
        /// <returns></returns>
        public List<string> GetIniList()
        {
            var list = new List<string>()
            {
                PlayfieldWidth.ToString(),
                PlayfieldHeight.ToString(),
                BackglassWidth.ToString(),
                BackglassHeight.ToString(),
                BackglassDisplayNumber.ToString(),
                BackglassXOffset.ToString(),
                BackglassYOffset.ToString(),
                DMDWidth.ToString(),
                DMDHeight.ToString(),
                DMDXOffset.ToString(),
                DMDYOffset.ToString(),
                YFlip.ToString()
            };
            return list;
        }
    }
}
