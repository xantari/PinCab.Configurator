//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Pincab.ScreenUtil.Utils
//{
//    public class ScreenDetails
//    {
//        [DllImport("User32.dll")]
//        public static extern IntPtr GetDC(IntPtr hwnd);
//        [DllImport("User32.dll")]
//        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
//        [DllImport("user32.dll")]
//        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

//        [DllImport("user32.dll")]
//        static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo mi);

//        delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

//        [StructLayout(LayoutKind.Sequential)]
//        public struct Rect
//        {
//            public int left;
//            public int top;
//            public int right;
//            public int bottom;
//        }


//        [StructLayout(LayoutKind.Sequential)]
//        struct MonitorInfo
//        {
//            public uint size;
//            public Rect monitor;
//            public Rect work;
//            public uint flags;
//        }

//        /// <summary>
//        /// Collection of display information
//        /// </summary>
//        public class DisplayInfoCollection : List<DisplayInfo>
//        {
//        }

//        /// <summary>
//        /// Returns the number of Displays using the Win32 functions
//        /// </summary>
//        /// <returns>collection of Display Info</returns>
//        public DisplayInfoCollection GetDisplays()
//        {
//            DisplayInfoCollection col = new DisplayInfoCollection();

//            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
//                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
//                {
//                    MonitorInfo mi = new MonitorInfo();
//                    mi.size = (uint)Marshal.SizeOf(mi);
//                    bool success = GetMonitorInfo(hMonitor, ref mi);
//                    if (success)
//                    {
//                        DisplayInfo di = new DisplayInfo();
//                        di.ScreenWidth = (mi.monitor.right - mi.monitor.left).ToString();
//                        di.ScreenHeight = (mi.monitor.bottom - mi.monitor.top).ToString();
//                        di.MonitorArea = mi.monitor;
//                        di.WorkArea = mi.work;
//                        di.Availability = mi.flags.ToString();
//                        col.Add(di);
//                    }
//                    return true;
//                }, IntPtr.Zero);
//            return col;
//        }

//        /// <summary>
//        /// The struct that contains the display information
//        /// </summary>
//        public class DisplayInfo
//        {
//            public string Availability { get; set; }
//            public string ScreenHeight { get; set; }
//            public string ScreenWidth { get; set; }
//            public Rect MonitorArea { get; set; }
//            public Rect WorkArea { get; set; }
//        }
//    }
//}
