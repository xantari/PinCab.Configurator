using IniParser;
using IniParser.Model;
using PinCab.ScreenUtil.Extensions;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils.DmdExt;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    /// <summary>
    /// DMDDevice.ini Utility
    /// </summary>
    public class DmdDeviceUtil
    {
        private string _dmdDeviceInitPath { get; set; }

        public const string ToolName = "DMDDevice.ini";

        private readonly Configuration _config;

        public DmdDeviceUtil(string dmdDeviceIniPath)
        {
            _dmdDeviceInitPath = dmdDeviceIniPath;
            if (File.Exists(_dmdDeviceInitPath))
            {
                _config = new Configuration(dmdDeviceIniPath);
            }
        }

        public void SaveSettings(List<DisplayDetail> displayDetails)
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\DMDDevice\\";
            var fileInfo = new FileInfo(_dmdDeviceInitPath);
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_hhMMss")}";
            File.Copy(_dmdDeviceInitPath, filePath);

            Log.Information("{ToolName}: Wrote settings backup: {location}", ToolName, filePath);

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));
            var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));
            SetDMDRegionRectangle(dmd, dmdRectangle);

            //Save the file
            _config.Save();
        }

        public RegionRectangle GetDMDRegionRectangle()
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_config.VirtualDmd.Height);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_config.VirtualDmd.Width);
            //The X and Y offsets are the virtual offsets based off of the window the DMD should be on
            regionRectangle.RegionOffsetX = Convert.ToInt32(_config.VirtualDmd.Left);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_config.VirtualDmd.Top);

            return regionRectangle;
        }

        public void SetDMDRegionRectangle(DisplayDetail display, RegionRectangle regionRectangle)
        {
            var position = new VirtualDisplayPosition();
            position.Height = regionRectangle.RegionDisplayHeight;
            position.Width = regionRectangle.RegionDisplayWidth;
            position.Left = display.VirtualResolutionOffsetX(regionRectangle);
            position.Top = display.VirtualResolutionOffsetY(regionRectangle);
            _config.VirtualDmd.SetPosition(position, false);
        }

        public void SetDisplayDetails(string section, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == section.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.ToLower().Contains(section.ToLower()));

            if (regionRectangle != null)
            {
                if (section == Consts.DMD)
                    SetDMDRegionRectangle(display, regionRectangle);
            }
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!File.Exists(_dmdDeviceInitPath))
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find DMDDevice.ini file. Have you defined it's location in settings yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdRegion = GetDMDRegionRectangle();

            if (dmdRegion != null)
            {
                var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

                if (dmdRegion.RegionDisplayHeight != dmdRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Height does not match. Expected: {dmdRectangle.RegionDisplayHeight} Actual: {dmdRegion.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (dmdRegion.RegionDisplayWidth != dmdRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Width does not match. Expected: {dmdRectangle.RegionDisplayWidth} Actual: {dmdRegion.RegionDisplayWidth}", MessageLevel.Error));
                }

                var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
                if (dmdRegion.RegionOffsetX != regionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {dmdRegion.RegionOffsetX}", MessageLevel.Error));
                }

                var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);
                if (dmdRegion.RegionOffsetY != regionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {dmdRegion.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"{ToolName}: No DMD Region defined. Skipping...", MessageLevel.Information));
            }

            if (result.Messages.HasAnyErrors())
                result.IsValid = false;

            result.Messages.Add(new ValidationMessage($"{ToolName}: Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }
}
