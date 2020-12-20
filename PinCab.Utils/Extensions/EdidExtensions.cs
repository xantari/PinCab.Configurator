using EDIDParser;
using EDIDParser.Descriptors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils
{
    public static class EdidExtensions
    {
        public static string GetDisplayEdidManufacturerAndSerial(this EDID edidInfo)
        {
            List<StringDescriptor> descriptors = new List<StringDescriptor>();
            foreach (var val in edidInfo.Descriptors)
            {
                if (val.GetType() == typeof(StringDescriptor))
                {
                    var description = val as StringDescriptor;
                    descriptors.Add(description);
                }
            }
            return string.Join(" - ", descriptors.Select(p => p.Value).ToArray());
        }

        public static EDID GetDisplayEdidData(this string devicePath)
        {
            var displayPath = devicePath.Split('#');

            if (!(displayPath.GetUpperBound(0) >= 2)) //Make sure we have all the display data to find the EDID info, if not leave it out. Really old monitors might not have this info
                return null;

            //Open the Display Reg-Key
            RegistryKey Display = Registry.LocalMachine;
            bool bFailed = false;
            try
            {
                Display = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY\" + displayPath[1] + "\\" + displayPath[2]);
            }
            catch
            {
                bFailed = true;
            }

            if (!bFailed & (Display != null))
            {
                var sSubkeys = Display.GetSubKeyNames();
                if (sSubkeys.Contains("Device Parameters"))
                {
                    RegistryKey DevParam = Display.OpenSubKey("Device Parameters");

                    //Get the EDID code
                    byte[] bObj = DevParam.GetValue("EDID", null) as byte[];
                    if (bObj != null)
                    {
                        return new EDID(bObj);
                    }
                    return null;
                }
            }
            return null;
        }
    }
}
