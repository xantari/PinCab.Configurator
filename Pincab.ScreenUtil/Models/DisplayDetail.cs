using EDIDParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDisplayAPI;

namespace PinCab.ScreenUtil
{
    [Serializable]
    public class DisplayDetail
    {
        public DisplayDetail() {
            RegionRectangles = new List<RegionRectangle>();
        }
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
        
        public List<RegionRectangle> RegionRectangles { get; set; }

        public override string ToString()
        {
            string temp = Display?.ToString();
            if (EdidInfo != null) 
                temp += " - " + EdidInfo.GetDisplayEdidManufacturerAndSerial();
            if (!string.IsNullOrEmpty(DisplayLabel))
                temp += " - " + DisplayLabel;
            return temp;
        }

        public int GetMonitorNumber()
        {
            var monitorNumber = Display.DisplayName.Replace("\\\\.\\DISPLAY", "");
            return Convert.ToInt32(monitorNumber);
        }

        // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        public float GetScalingFactor() //https://stackoverflow.com/questions/5977445/how-to-get-windows-display-settings
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }

        public int VirtualLeft()
        {
            return Display.CurrentSetting.Position.X;
        }
        public int VirtualTop()
        {
            return Display.CurrentSetting.Position.Y;
        }
        public int VirtualRight()
        {
            return Display.CurrentSetting.Position.X + Display.CurrentSetting.Resolution.Width;
        }
        public int VirtualBottom()
        {
            return Display.CurrentSetting.Position.Y + Display.CurrentSetting.Resolution.Height;
        }
    }
}
