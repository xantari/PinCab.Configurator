using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinupPopper
{
    public class Screen
    {
        public Screen()
        { 
        }

        public int ScreenID { get; set; }
        //Max Length 50
        public int ScreeName { get; set; }
        //Max Length 50
        public string ScreenDisplay { get; set; }
        public int POSx { get; set; }
        public int POSy { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public int WindowState { get; set; }
        public int FullScreen { get; set; }
        public int Visible { get; set; }
        public int VerifyPOS { get; set; }
        public int Rotation { get; set; }
        public int MonitorNum { get; set; }
        public int ScreenType { get; set; }
        public int RotateThumbs { get; set; }
        public int ThumbWidth { get; set; }
        public int ThumbHeight { get; set; }
        public int AlphaBlend { get; set; }
    }
}
