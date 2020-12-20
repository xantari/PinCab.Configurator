using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    /// <summary>
    /// Pinup Player Settings
    /// INFO = Topper
    /// INFO1 = DMD (4:1 Slim)
    /// INFO2 = Backglass
    /// INFO3 = Playfield
    /// INFO4 = Music
    /// INFO5 = Apron/FullDMD
    /// INFO6 = Game Select
    /// INFO7 = Loading
    /// INFO8 = Other 2
    /// INFO9 = GameInfo
    /// INFO10 = GameHelp
    /// </summary>
    public class PinupPlayerSetting
    {
        /// <summary>
        /// INFO, INFO1, INFO2, etc
        /// </summary>
        public string SectionName { get; set; }
        public int ScreenXPos { get; set; }
        public int ScreenYPos { get; set; }
        /// <summary>
        /// Virtual coordinate screen width
        /// </summary>
        public int ScreenWidth { get; set; }
        /// <summary>
        /// Virtual coordinate screen height
        /// </summary>
        public int ScreenHeight { get; set; }
        /// <summary>
        /// Volume 0 to 100
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// 0 = Show Always On
        /// 1 = Show Popup (Hide Paused)
        /// 2 = Hide Always (sound only)
        /// 3 = Off (disable)
        /// </summary>
        public int HideStopped { get; set; }
        public int AspectWide { get; set; }
        public int AspectHigh { get; set; }
        public int fitToWindow { get; set; }
        /// <summary>
        /// 0, 90, 180, 270 possible values
        /// </summary>
        public int ScreenRotation { get; set; }
        public int DebugMode { get; set; }
        public int VideoDriver { get; set; }
        public int FirstRun { get; set; }
    }
}
