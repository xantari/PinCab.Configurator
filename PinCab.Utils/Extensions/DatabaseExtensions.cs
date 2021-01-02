using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIrtualPinball.Database.Models;

namespace PinCab.Utils.Extensions
{
    public static class DatabaseExtensions
    {
        public static List<string> ConvertTableInfoToTags(this TableInfo info)
        {
            var list = new List<string>();
            if (info != null)
            {
                if (!string.IsNullOrEmpty(info.Manufacturer))
                    list.Add(info.Manufacturer);
                if (!string.IsNullOrEmpty(info.MPU))
                    list.Add(info.MPU);
                if (info.Players.HasValue)
                    list.Add(info.Players.Value == 1 ? "1 Player" : "{info.Players.Value} Players");
                if (!string.IsNullOrEmpty(info.Theme))
                    list.Add(info.Theme);
                if (!string.IsNullOrEmpty(info.VPVersion))
                    list.Add(info.VPVersion);
                if (info.Year.HasValue)
                    list.Add(info.Year.Value.ToString());
            }
            return list;
        }

        public static List<string> ConvertFeatureFlagsToTags(this FeatureFlags info)
        {
            var list = new List<string>();
            if (info != null)
            {
                if (info.Desktop)
                    list.Add("Desktop");
                if (info.FastFlips)
                    list.Add("FastFlips");
                if (info.Fss)
                    list.Add("FSS");
                if (info.Mod)
                    list.Add("MOD");
                if (info.Music)
                    list.Add("Music");
                if (info.PRoc)
                    list.Add("P-ROC");
                if (info.PupPack)
                    list.Add("Pup Pack");
                if (info.Res4k)
                    list.Add("4K");
                if (info.Ssf)
                    list.Add("SSF");
                if (info.UltraDmd)
                    list.Add("UltraDMD");
                if (info.Vr)
                    list.Add("VR");
            }
            return list;
        }
    }
}
