using Pincab.ScreenUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil
{
    public static class DisplayDetailsExtensions
    {
        public static DisplayDetail GetByDisplayName(this List<DisplayDetail> displayDetails, string displayName)
        {
            foreach(var display in displayDetails)
            {
                if (display.Display.DisplayName == displayName)
                    return display;
            }
            return null;
        }
    }
}
