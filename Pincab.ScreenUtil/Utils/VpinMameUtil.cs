using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil.Utils
{
    public class VpinMameUtil
    {
        public VpinMameUtil() { }

        //public static string PinMameRegistryKeyLocation = @"Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame";
        //public static string PinMameDefaultKey = @"Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame\Default";

        public bool KeyExists()
        {
            //Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame
            return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame") != null;
        }

        //public void SetPinMameDefaultKeyPosition(RegionRectangle dmdRectangle)
        //{
        //    //Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame
        //    return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame") != null;
        //}

        //public void SetPinMamePositionForAllPreviousRunROMs(RegionRectangle dmdRectangle)
        //{
        //    //Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame
        //    return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame") != null;
        //}

        public void ValidatePinMameDefaultKeyPosition(RegionRectangle dmdRectangle)
        {

        }

        public void ValidatePinMamePositionAllPreviousRunROMs(RegionRectangle dmdRectangle)
        {

        }
    }
}
