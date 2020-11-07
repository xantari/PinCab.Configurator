using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    public class UltraDmdUtil
    {
        private const string ToolName = "UltraDMD/FlexDMD";

        public UltraDmdUtil() { }

        public bool KeyExists()
        {
            //Computer\HKEY_CURRENT_USER\Software\UltraDMD
            return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("UltraDMD") != null;
        }

       
    }
}
