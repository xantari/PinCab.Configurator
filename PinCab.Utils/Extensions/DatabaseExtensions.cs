using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPinball.Database.Models;

namespace PinCab.Utils.Extensions
{
    public static class DatabaseExtensions
    {
        public static List<string> ConvertTableInfoToTags(this DatabaseEntry info)
        {
            var list = new List<string>();
            if (info != null)
            {
                if (!string.IsNullOrEmpty(info.Manufacturer))
                    list.Add(info.Manufacturer);
                if (info.Players.HasValue)
                    list.Add(info.Players.Value == 1 ? "1 Player" : $"{info.Players.Value} Players");
                if (!string.IsNullOrEmpty(info.Theme))
                    list.Add(info.Theme);
                if (info.Year.HasValue)
                    list.Add(info.Year.Value.ToString());
            }
            return list;
        }
    }
}
