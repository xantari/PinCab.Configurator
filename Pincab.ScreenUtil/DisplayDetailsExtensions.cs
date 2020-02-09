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

        public static int VirtualResolutionWidth(this DisplayDetail display)
        {
            return display.Display.CurrentSetting.Position.X + display.Display.CurrentSetting.Resolution.Width;
        }

        public static int VirtualResolutionHeight(this DisplayDetail display)
        {
            return display.Display.CurrentSetting.Position.Y + display.Display.CurrentSetting.Resolution.Height;
        }

        /// <summary>
        /// Upper left hand corner X position of region rectangle
        /// </summary>
        /// <param name="display"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static int VirtualResolutionOffsetX(this DisplayDetail display, RegionRectangle region)
        {
            return display.Display.CurrentSetting.Position.X + region.RegionOffsetX;
        }
        /// <summary>
        /// Upper left hand corner Y position of region rectangle
        /// </summary>
        /// <param name="display"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static int VirtualResolutionOffsetY(this DisplayDetail display, RegionRectangle region)
        {
            return display.Display.CurrentSetting.Position.Y + region.RegionOffsetY;
        }

        public static int VirtualResolutionOffsetXLowerRightCorner(this DisplayDetail display, RegionRectangle region)
        {
            return display.Display.CurrentSetting.Position.X + region.RegionOffsetX + region.RegionDisplayWidth;
        }

        public static int VirtualResolutionOffsetYLowerRightCorner(this DisplayDetail display, RegionRectangle region)
        {
            return display.Display.CurrentSetting.Position.Y + region.RegionOffsetY + region.RegionDisplayHeight;
        }
    }
}
