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
    /// <summary>
    /// VPinMame Utility
    /// 
    /// Registry Key Info:
    /// showpindmd: "Use External DMD", aka DMDDevice.ini, aka Freezy DMDExt or PinDMD. Valid values: 0,1 (false,true)
    /// showwindmd: Show the normal VpinMame DMD, normally false if showpindmd = 1. Valid values: 0,1 (false,true)
    /// at91jit: https://vpinball.com/wiki/visual-pinball-knowledge-base/turning-onoff-at91jit/ and http://vpuniverse.com/forums/topic/2728-sam-build-with-modular-dmd-drivers-for-pindmd123-and-pin2dmd/page/20/?tab=comments#comment-33425
    /// dmd_height: Height of DMD
    /// dmd_width: Width of DMD
    /// dmd_pos_x: Virtual X offset of DMD upper left hand corner
    /// dmd_pos_y: Virtual Y offset of DMD upper left hand corner
    /// </summary>
    public class VpinMameUtil
    {
        public const string ToolName = "VPinMAME";
        public VpinMameUtil() { }

        private const string PinMameRegistryKeyLocation = @"Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame";
        private const string PinMameDefaultKey = @"Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame\Default";

        public bool KeyExists()
        {
            //Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame
            return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame") != null;
        }

        public ValidationResult SetPinMameDefault(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

            var setResult = SetDMDRegionRectangle("default", dmd.GetRectangleWithVirtualOffsets(dmdRectangle));

            if (!setResult.IsValid)
            {
                result.IsValid = false;
                result.Messages.AddRange(setResult.Messages);
            }

            return result;
        }

        public ValidationResult SetPinMamePositionAllROMs(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\VPinMame\\";
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"VpinMame_AllKeys_{DateTime.Now.ToString("yyyy-MM-dd_hhMMss")}.reg";

            using (var keyToBackup = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame"))
            {
                RegistryUtil.ExportViaRegExe(keyToBackup.Name, filePath);
                keyToBackup.Close();
            }

            var keys = GetAllRomKeyNames();
            foreach(var key in keys)
            {
                var setResult = SetDMDRegionRectangle(key, dmd.GetRectangleWithVirtualOffsets(dmdRectangle), false); //We've already backed up all keys, don't backup the individual keys

                if (!setResult.IsValid)
                {
                    result.IsValid = false;
                    result.Messages.AddRange(setResult.Messages);
                }
            }


            result.Messages.Add(new ValidationMessage($"{ VpinMameUtil.ToolName }: Write command completed.", MessageLevel.Information));

            return result;
        }

        public RegionRectangle GetDMDRegionRectangle(string key)
        {
            if (key == null)
                return null;

            RegionRectangle regionRectangle = null;
            using (var regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame").OpenSubKey(key))
            {
                if (regKey != null)
                {
                    regionRectangle = new RegionRectangle();
                    if (regKey.GetValue("dmd_height") != null)
                        regionRectangle.RegionDisplayHeight = Convert.ToInt32(regKey.GetValue("dmd_height"));
                    if (regKey.GetValue("dmd_width") != null)
                        regionRectangle.RegionDisplayWidth = Convert.ToInt32(regKey.GetValue("dmd_width"));
                    if (regKey.GetValue("dmd_pos_x") != null) //These are virtual positions
                        regionRectangle.RegionOffsetX = Convert.ToInt32(regKey.GetValue("dmd_pos_x"));
                    if (regKey.GetValue("dmd_pos_y") != null) //These are virtual positions
                        regionRectangle.RegionOffsetY = Convert.ToInt32(regKey.GetValue("dmd_pos_y"));
                    regKey.Close();
                }
            }

            return regionRectangle;
        }

        public ValidationResult SetDMDRegionRectangle(string key, RegionRectangle regionRectangle, bool backupKey = true)
        {
            var result = new ValidationResult();
            if (key == null)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage() { Level = MessageLevel.Information, Message = "Key name missing" });
                return result;
            }

            //Backup the registry
            if (backupKey)
            {
                var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\VPinMame\\";
                Directory.CreateDirectory(currentFolder);
                string filePath = currentFolder + $"VpinMame_{key}_{DateTime.Now.ToString("yyyy-MM-dd_hhMMss")}.reg";
                var keyToBackup = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(key);
                if (keyToBackup != null)
                {
                    RegistryUtil.ExportViaRegExe(keyToBackup.Name, filePath);
                    keyToBackup.Close();
                }
                else
                {
                    Log.Information("{ToolName}: Key: {key} not found to backup", ToolName, key);
                }

                Log.Information("{ToolName}: Wrote settings backup: {location}", ToolName, filePath);
            }

            using (var regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(key, true))
            {
                try
                {
                    if (regKey != null)
                    {
                        regKey.SetValue("dmd_height", regionRectangle.RegionDisplayHeight);
                        regKey.SetValue("dmd_width", regionRectangle.RegionDisplayWidth);
                        regKey.SetValue("dmd_pos_x", regionRectangle.RegionOffsetX); //These are virtual positions
                        regKey.SetValue("dmd_pos_y", regionRectangle.RegionOffsetY); //These are virtual positions
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    var msg = "Unauthorized access to set registry key. Did you run the program as admin?";
                    Log.Error(ex, msg);
                    return new ValidationResult() { IsValid = false, Messages = new List<ValidationMessage>() { new ValidationMessage(msg, MessageLevel.Error) } };
                }
                finally
                {
                    regKey.Close();
                }
            }
            return result;
        }

        public ValidationResult ValidatePinMameDefaultKeyPosition(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            using (var defaultKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey("default"))
            {
                if (defaultKey != null)
                {
                    var dmdFromRegistry = GetDMDRegionRectangle("default");
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
                     ($"{ToolName}: Unable to find VPinMame default key. Skipping...", MessageLevel.Information));
                }
            }

            return result;
        }

        public ValidationResult ValidatePinMamePositionAllROMs(List<DisplayDetail> displayDetails, ReportProgressDelegate reportProcess)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var keys = GetAllRomKeyNames();
            Log.Information("{ToolName}: Processing {count} keys.", ToolName, keys.Count());
            int count = 0;
            foreach (var key in keys)
            {
                var percentComplete =  Convert.ToInt32(Math.Round(count / Convert.ToDouble(keys.Count()) * 100));
                reportProcess(percentComplete);
                count++;
                using (var romKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(key))
                {
                    if (romKey != null)
                    {
                        var dmdFromRegistry = GetDMDRegionRectangle(key);
                        var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

                        if (dmdFromRegistry.RegionDisplayHeight != dmdRectangle.RegionDisplayHeight)
                        {
                            result.Messages.Add(new ValidationMessage
                                ($"{ToolName}: ROM: {key}. {dmdRectangle.RegionLabel} Region Display Height does not match. Expected: {dmdRectangle.RegionDisplayHeight} Actual: {dmdFromRegistry.RegionDisplayHeight}", MessageLevel.Error));
                        }

                        if (dmdFromRegistry.RegionDisplayWidth != dmdRectangle.RegionDisplayWidth)
                        {
                            result.Messages.Add(new ValidationMessage
                                ($"{ToolName}: ROM: {key}. {dmdRectangle.RegionLabel} Region Display Width does not match. Expected: {dmdRectangle.RegionDisplayWidth} Actual: {dmdFromRegistry.RegionDisplayWidth}", MessageLevel.Error));
                        }

                        var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
                        if (dmdFromRegistry.RegionOffsetX != regionOffsetX)
                        {
                            result.Messages.Add(new ValidationMessage
                                ($"{ToolName}: ROM: {key}. {dmdRectangle.RegionLabel} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {dmdFromRegistry.RegionOffsetX}", MessageLevel.Error));
                        }

                        var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);
                        if (dmdFromRegistry.RegionOffsetY != regionOffsetY)
                        {
                            result.IsValid = false;
                            result.Messages.Add(new ValidationMessage
                                ($"{ToolName}: ROM: {key}. {dmdRectangle.RegionLabel} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {dmdFromRegistry.RegionOffsetY}", MessageLevel.Error));
                        }
                    }
                    else
                    {
                        result.Messages.Add(new ValidationMessage
                         ($"{ToolName}: ROM: {key}. Unable to find VPinMame ROM key. Skipping...", MessageLevel.Information));
                    }
                }
            }
            Log.Information("{ToolName}: Finished Processing {count} keys.", ToolName, keys.Count());

            return result;
        }

        public delegate void ReportProgressDelegate(int percentage);

        public List<RegistryKey> GetKeysOfAllRoms(bool excludeDefault = true, bool openForWrite = false)
        {
            var subkeys = GetAllRomKeyNames(excludeDefault);
            List<RegistryKey> keys = new List<RegistryKey>();
            foreach (var subkey in subkeys)
            {
                var key = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(subkey, openForWrite);
                keys.Add(key);
            }

            return keys;
        }

        public void CloseAllRomKeys(List<RegistryKey> keys)
        {
            foreach (var key in keys)
                key.Close();
        }

        public string[] GetAllRomKeyNames(bool excludeDefault = true)
        {
            var keys = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.GetSubKeyNames();
            if (excludeDefault)
                return keys.Where(p => p != "default").ToArray();
            return keys;
        }
    }
}
