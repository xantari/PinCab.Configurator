using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinupPopper
{
    public class Emulator
    {
        public int EMUID { get; set; }
        public string EmuName { get; set; }
        public string Description { get; set; }
        public string DirGames { get; set; }
        public string DirMedia { get; set; }
        public string EmuDisplay { get; set; }
        public int Visible { get; set; }
        public string DirRoms { get; set; }
        public string EmuLaunchDir { get; set; }
        public int HideScreens { get; set; }
        public string GamesExt { get; set; }
        public string ImageExt { get; set; }
        public string VideoExt { get; set; }
        public int EscapeKeyCode { get; set; }
        public string LaunchScript { get; set; }
        public string PostScript { get; set; }
        public string KeepDisplays { get; set; }
        public string ProcessName { get; set; }
        public string WinTitle { get; set; }
        public int SkipScan { get; set; }
        public int emuVolume { get; set; }
        public string DirGamesShare { get; set; }
        public string DirRomsShare { get; set; }
        public string DirMediaShare { get; set; }
        public int CanPause { get; set; }
        public string CoreFile { get; set; }
        public string HelpScript { get; set; }
        public int AutoScanStartup { get; set; }
        public string IgnoreFileScan { get; set; }
        public int SafeLaunch { get; set; }
        public int SafeReturn { get; set; }
    }
}
