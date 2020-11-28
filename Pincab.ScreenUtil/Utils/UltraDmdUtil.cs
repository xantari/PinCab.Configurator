using Microsoft.Win32;
using PinCab.ScreenUtil.Extensions;
using PinCab.ScreenUtil.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    public class UltraDmdUtil
    {
        public const string ToolName = "UltraDMD";

        public UltraDmdUtil() { }

        public bool KeyExists()
        {
            //Computer\HKEY_CURRENT_USER\Software\UltraDMD
            var key = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("UltraDMD");
            key.Close();
            return key != null;
        }

        private RegistryKey GetRegKey()
        {
            return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("UltraDMD", RegistryKeyPermissionCheck.ReadWriteSubTree);
        }

        public RegionRectangle GetDMDRegionRectangle()
        {
            if (!KeyExists())
                return null;
            var regionRectangle = new RegionRectangle();
            using (var key = GetRegKey())
            {
                if (key.GetValue("h") != null)
                    regionRectangle.RegionDisplayHeight = Convert.ToInt32(key.GetValue("h"));
                if (key.GetValue("w") != null)
                    regionRectangle.RegionDisplayWidth = Convert.ToInt32(key.GetValue("w"));
                if (key.GetValue("x") != null)
                    regionRectangle.RegionOffsetX = Convert.ToInt32(key.GetValue("x"));
                if (key.GetValue("y") != null)
                    regionRectangle.RegionOffsetY = Convert.ToInt32(key.GetValue("y"));
                key.Close();
            }

            return regionRectangle;
        }

        public ValidationResult SetDMDRegionRectangle(DisplayDetail display, RegionRectangle regionRectangle)
        {
            if (!KeyExists())
                return new ValidationResult() { IsValid = false, Messages = new List<ValidationMessage>() { new ValidationMessage("Registry key does not exist", MessageLevel.Error) } };
            using (var key = GetRegKey())
            {
                try
                {
                    key.SetValue("h", regionRectangle.RegionDisplayHeight);
                    key.SetValue("w", regionRectangle.RegionDisplayWidth);
                    key.SetValue("x", display.VirtualResolutionOffsetX(regionRectangle));
                    key.SetValue("y", display.VirtualResolutionOffsetY(regionRectangle));
                }
                catch (UnauthorizedAccessException ex)
                {
                    var msg = "Unauthorized access to set registry key. Did you run the program as admin?";
                    Log.Error(ex, msg);
                    return new ValidationResult() { IsValid = false, Messages = new List<ValidationMessage>() { new ValidationMessage(msg, MessageLevel.Error) } };
                }
                finally
                {
                    key.Close();
                }
            }

            return new ValidationResult();
        }

        public ValidationResult SaveSettings(List<DisplayDetail> displayDetails)
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\UltraDMD\\";
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"UltraDMD_{DateTime.Now.ToString("yyyy-MM-dd_hhMMss")}.reg";

            //Backup the registry
            using (var key = GetRegKey())
            {
                RegistryUtil.ExportViaRegExe(key.Name, filePath);
                key.Close();
            }

            Log.Information("{ToolName}: Wrote settings backup: {location}", ToolName, filePath);

            //Set the registry keys
            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));
            var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));
            var result = SetDMDRegionRectangle(dmd, dmdRectangle);
            return result;
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find UltraDMD Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdFromRegistry = GetDMDRegionRectangle();

            if (dmdFromRegistry != null)
            {
                var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

                if (dmdFromRegistry.RegionDisplayHeight != dmdRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Height does not match. Expected: {dmdRectangle.RegionDisplayHeight} Actual: {dmdFromRegistry.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (dmdFromRegistry.RegionDisplayWidth != dmdRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Width does not match. Expected: {dmdRectangle.RegionDisplayWidth} Actual: {dmdFromRegistry.RegionDisplayWidth}", MessageLevel.Error));
                }

                var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
                if (dmdFromRegistry.RegionOffsetX != regionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {dmdFromRegistry.RegionOffsetX}", MessageLevel.Error));
                }

                var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);
                if (dmdFromRegistry.RegionOffsetY != regionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {dmdFromRegistry.RegionOffsetY}", MessageLevel.Error));
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
