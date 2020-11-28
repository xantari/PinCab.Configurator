using PinCab.ScreenUtil;
using PinCab.ScreenUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil
{
    public static class DisplayDetailsExtensions
    {
        public static DisplayDetail GetByDisplayName(this List<DisplayDetail> displayDetails, string displayName)
        {
            foreach (var display in displayDetails)
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

        public static RegionRectangle GetRectangleWithVirtualOffsets(this DisplayDetail display, RegionRectangle region)
        {
           return new RegionRectangle(region.RegionDisplayHeight, region.RegionDisplayWidth,
                    display.VirtualResolutionOffsetX(region), display.VirtualResolutionOffsetY(region));
        }

        public static List<string> GetFfMpegCommandsForAllMonitors(this List<DisplayDetail> displayDetails, int framerate, TimeSpan recordTime,
            string pathToTempFolder, string ffmpegExePath)
        {
            var commands = new List<string>();

            //TimeToSaveVideo = 00:00:30
            //video resolution = 1880x500
            string FFmpegCommandTemplate = ffmpegExePath + @" -f gdigrab -framerate {framerate} -offset_x {offsetX} -offset_y {offsetY} -video_size {videoresolution} -t {timeToSaveVideo} -i desktop -c:v h264_nvenc -an -qp 21 -pix_fmt yuv420p -movflags +faststart {pathToSaveFile}";
            foreach (var display in displayDetails)
            {
                string frameRate = framerate.ToString();
                string offsetX, offsetY, videoHeight, videoWidth;
                offsetX = offsetY = videoHeight = videoWidth = string.Empty;

                if (display.RegionRectangles.Count() > 0)
                {
                    foreach (var region in display.RegionRectangles)
                    {
                        if (region.RegionOffsetX != 0) //They have configured a custom resolution to capture, meaning not full screen
                            offsetX = (display.Display.CurrentSetting.Position.X + region.RegionOffsetX).ToString();
                        else
                            offsetX = display.Display.CurrentSetting.Position.X.ToString();

                        if (region.RegionOffsetY != 0) //They have configured a custom resolution to capture, meaning not full screen
                            offsetY = (display.Display.CurrentSetting.Position.Y + region.RegionOffsetY).ToString();
                        else
                            offsetY = display.Display.CurrentSetting.Position.Y.ToString();

                        if (region.RegionDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                            videoHeight = region.RegionDisplayHeight.ToString();
                        else
                            videoHeight = display.Display.CurrentSetting.Resolution.Height.ToString();

                        if (region.RegionDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                            videoWidth = region.RegionDisplayWidth.ToString();
                        else
                            videoWidth = display.Display.CurrentSetting.Resolution.Width.ToString();

                        string videoResolution = $"{videoWidth}x{videoHeight}";
                        string timeToSaveVideo = recordTime.ToString(); //"00:00:30"; //30 seconds

                        string pathToSaveVideo = pathToTempFolder + (display.ToString() + " - " + region.RegionLabel).RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

                        commands.Add(FFmpegCommandTemplate.Replace("{framerate}", frameRate)
                                    .Replace("{offsetX}", offsetX)
                                    .Replace("{offsetY}", offsetY)
                                    .Replace("{videoresolution}", videoResolution)
                                    .Replace("{timeToSaveVideo}", timeToSaveVideo)
                                    .Replace("{pathToSaveFile}", pathToSaveVideo));
                    }
                }
                else //Capture the single display info with region offsets
                {
                    string videoResolution = $"{videoWidth}x{videoHeight}";
                    string timeToSaveVideo = recordTime.ToString(); //"00:00:30"; //30 seconds
                    string pathToSaveVideo = pathToTempFolder + display.ToString().RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

                    commands.Add(FFmpegCommandTemplate.Replace("{framerate}", frameRate)
                                .Replace("{offsetX}", offsetX)
                                .Replace("{offsetY}", offsetY)
                                .Replace("{videoresolution}", videoResolution)
                                .Replace("{timeToSaveVideo}", timeToSaveVideo)
                                .Replace("{pathToSaveFile}", pathToSaveVideo));
                }
            }
            return commands;
        }

        public static ValidationResult ValidateDisplayConfiguration(this List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            //Ensure no monitors have negative coordinates (always left to right)
            foreach (var display in displayDetails)
            {
                if (display.Display.CurrentSetting.Position.X < 0 || display.Display.CurrentSetting.Position.Y < 0)
                {
                    result.Messages.Add(new ValidationMessage($"Invalid monitor configuration detected due to negative position values. Virtual Pinball programs require all monitors to have positive position values. Monitor: {display.ToString()} {display.Display.CurrentSetting.Position.ToString()}", MessageLevel.Error));
                    result.IsValid = false;
                }
                var scalingFactor = display.GetScalingFactor();
                if (scalingFactor != 1.0f)
                {
                    result.Messages.Add(new ValidationMessage($"Scaling factor not set to 100%. Change your DPI settings to be 100%. Current Scaling: {(scalingFactor * 100)}%. Monitor: {display.ToString()} {display.Display.CurrentSetting.Position.ToString()}", MessageLevel.Error));
                    result.IsValid = false;
                }
            }
            if (!displayDetails.Any(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.Playfield.ToLower())))
            {
                result.Messages.Add(new ValidationMessage($"No Playfield display selected yet. Please select a playfield display and give it a region label of Playfield.", MessageLevel.Error));
                result.IsValid = false;
            }
            var playfieldDisplay = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.Playfield.ToLower()));
            if (playfieldDisplay != null && !playfieldDisplay.Display.IsGDIPrimary)
            {
                result.Messages.Add(new ValidationMessage($"Your playfield display must be monitor 1 and marked as the primary monitor.", MessageLevel.Error));
                result.IsValid = false;
            }
            //Check if DMD is recommended 4:1 ratio
            var dmdDisplay = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.Contains(Consts.DMD)));
            var regionDmdRectangle = dmdDisplay?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));
            if (regionDmdRectangle == null)
            {
                result.Messages.Add(new ValidationMessage($"Unable to locate DMD monitor. Have you specified it yet?", MessageLevel.Error));
                result.IsValid = false;
            }
            else
            {
                if (regionDmdRectangle.RegionDisplayHeight == 0 || regionDmdRectangle.RegionDisplayWidth == 0)
                {
                    result.Messages.Add(new ValidationMessage("DMD Region incomplete.Width or Height is specified as 0.", MessageLevel.Error));
                    result.IsValid = false;
                }
                else
                {
                    if ((regionDmdRectangle.RegionDisplayHeight / Convert.ToDecimal(regionDmdRectangle.RegionDisplayWidth)) != 0.25M) //Not a 4:1 ratio
                    {
                        result.Messages.Add(new ValidationMessage($"WARNING: DMD Region is not recommended 4:1 ratio.", MessageLevel.Warning));
                    }
                }
            }

            return result;
        }
    }
}
