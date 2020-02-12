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

        public static List<string> GetFfMpegCommandsForAllMonitors(this List<DisplayDetail> displayDetails, int framerate, TimeSpan recordTime)
        {
            var commands = new List<string>();

            //TimeToSaveVideo = 00:00:30
            //video resolution = 1880x500
            string FFmpegCommandTemplate = @"FFMPEG.exe -f gdigrab -framerate {framerate} -offset_x {offsetX} -offset_y {offsetY} -video_size {videoresolution} -t {timeToSaveVideo} -i desktop -c:v h264_nvenc -an -qp 21 -pix_fmt yuv420p -movflags +faststart {pathToSaveFile}";
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
                        string timeToSaveVideo = recordTime.ToString("hh:mm:ss"); //"00:00:30"; //30 seconds
                        string pathToSaveVideo = "C:\\" + (display.ToString() + " - " + region.RegionLabel).RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

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
                    string timeToSaveVideo = recordTime.ToString("hh:mm:ss"); //"00:00:30"; //30 seconds
                    string pathToSaveVideo = "C:\\" + display.ToString().RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

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
    }
}
