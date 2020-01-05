using EDIDParser;
using EDIDParser.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil
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
    }
}
