using Microsoft.Win32;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
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

        public ValidationResult SetPinMamePositionAllROMs(List<DisplayDetail> displayDetails, bool onlyPreviousRunRoms, ReportProgressDelegate reportProcess = null)
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
            string filePath = currentFolder + $"VpinMame_AllKeys_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.reg";

            using (var keyToBackup = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame"))
            {
                RegistryUtil.ExportViaRegExe(keyToBackup.Name, filePath);
                keyToBackup.Close();
            }

            var keys = GetAllRomKeyNames(true, onlyPreviousRunRoms);
            result.Messages.Add(new ValidationMessage() { Level = MessageLevel.Information, Message = $"Setting DMD rectangle position on all previously run roms. Count: {keys.Count()}" });
            int count = 0;
            foreach (var key in keys)
            {
                var percentComplete = Convert.ToInt32(Math.Round(count / Convert.ToDouble(keys.Count()) * 100));
                reportProcess?.Invoke(percentComplete);
                count++;
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

        public ValidationResult SetPinMamePositionAllROMs(VpinMameRomSetting setting, bool onlyPreviousRunRoms, ReportProgressDelegate reportProcess = null)
        {
            var result = new ValidationResult();

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\VPinMame\\";
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"VpinMame_AllKeys_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.reg";

            using (var keyToBackup = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame"))
            {
                RegistryUtil.ExportViaRegExe(keyToBackup.Name, filePath);
                keyToBackup.Close();
            }

            var keys = GetAllRomKeyNames(true, onlyPreviousRunRoms);
            result.Messages.Add(new ValidationMessage() { Level = MessageLevel.Information, Message = $"Setting registry key values on all previously run roms. Count: {keys.Count()}" });
            int count = 0;
            foreach (var key in keys)
            {
                var percentComplete = Convert.ToInt32(Math.Round(count / Convert.ToDouble(keys.Count()) * 100));
                reportProcess?.Invoke(percentComplete);
                count++;
                setting.RomName = key;
                SaveRomModelToRegsitry(setting);
            }

            result.Messages.Add(new ValidationMessage($"{ VpinMameUtil.ToolName }: Write command completed.", MessageLevel.Information));

            return result;
        }

        public ValidationResult SetPinMamePositionAllROMs(VpinMameRomSetting setting, List<string> PropertiesToCopy, bool onlyPreviousRunRoms, ReportProgressDelegate reportProcess = null)
        {
            var result = new ValidationResult();

            if (!KeyExists())
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find VPinMame Registry key. Have you installed it yet?", MessageLevel.Error));
            }

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\VPinMame\\";
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"VpinMame_AllKeys_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.reg";

            using (var keyToBackup = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame"))
            {
                RegistryUtil.ExportViaRegExe(keyToBackup.Name, filePath);
                keyToBackup.Close();
            }

            var keys = GetAllRomKeyNames(true, onlyPreviousRunRoms);
            result.Messages.Add(new ValidationMessage() { Level = MessageLevel.Information, Message = $"Setting registry key values on all previously run roms. Count: {keys.Count()}" });
            int count = 0;
            foreach (var key in keys)
            {
                var percentComplete = Convert.ToInt32(Math.Round(count / Convert.ToDouble(keys.Count()) * 100));
                reportProcess?.Invoke(percentComplete);
                count++;
                var model = GetRomModel(key);
                foreach(var name in PropertiesToCopy)
                {
                    object val = setting.GetPropValue(name);
                    model.SetPropValue(name, val);
                }
                SaveRomModelToRegsitry(model);
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
                string filePath = currentFolder + $"VpinMame_{key}_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}.reg";
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

        public ValidationResult ValidatePinMamePositionAllROMs(List<DisplayDetail> displayDetails, bool onlyPreviousRunRoms, ReportProgressDelegate reportProcess = null)
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

            var keys = GetAllRomKeyNames(true, onlyPreviousRunRoms);
            Log.Information("{ToolName}: Processing {count} keys.", ToolName, keys.Count());
            result.Messages.Add(new ValidationMessage() { Level = MessageLevel.Information, Message = $"Validating DMD rectangle position on all previously run roms. Count: {keys.Count()}" });
            int count = 0;
            foreach (var key in keys)
            {
                var percentComplete = Convert.ToInt32(Math.Round(count / Convert.ToDouble(keys.Count()) * 100));
                reportProcess?.Invoke(percentComplete);
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

        public string[] GetAllRomKeyNames(bool excludeDefault = true, bool onlyPreviousRunRoms = true)
        {
            var keys = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.GetSubKeyNames();
            if (excludeDefault)
                keys = keys.Where(p => p != "default").ToArray();
            //Always exclude global
            keys = keys.Where(p => p != "globals").ToArray();
            if (onlyPreviousRunRoms)
            {
                List<string> tempKeys = new List<string>();
                foreach (var key in keys)
                {
                    var regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(key);
                    if (regKey.GetValueNames().Count() > 1) //If a ROM has been run it will have a lot of keys here, more then the single "Default" key
                    {
                        tempKeys.Add(key);
                    }
                }
                keys = tempKeys.ToArray();
            }
            return keys;
        }

        public List<VpinMameRomSetting> GetAllRomDetails(bool excludeDefault = false, bool onlyPreviousRunRoms = true)
        {
            var roms = new List<VpinMameRomSetting>();

            if (!KeyExists())
                return roms;

            var keys = GetAllRomKeyNames(excludeDefault, onlyPreviousRunRoms);

            foreach (var key in keys)
            {
                var regKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(key);
                var model = LoadRomModel(regKey);
                roms.Add(model);
            }

            return roms;
        }

        public VpinMameRomSetting GetRomModel(string romKeyName)
        {
            var key = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(romKeyName);
            var model = LoadRomModel(key);
            if (key != null)
                key.Close();
            return model;
        }

        private VpinMameRomSetting LoadRomModel(RegistryKey key)
        {
            if (key == null)
                return null;
            var model = new VpinMameRomSetting();
            model.RomName = key.Name.Substring(key.Name.LastIndexOf("\\") + 1, key.Name.Length - key.Name.LastIndexOf("\\") - 1);
            var valueList = key.GetValueNames();
            if (valueList.Contains("antialias"))
                model.EnableAntiAlias = Convert.ToBoolean(key.GetValue("antialias"));
            if (valueList.Contains("cheat"))
                model.SkipStartup = Convert.ToBoolean(key.GetValue("cheat"));
            if (valueList.Contains("dmd_antialias"))
                model.AntiAliasPercentage = Convert.ToInt32(key.GetValue("dmd_antialias"));
            if (valueList.Contains("dmd_opacity"))
                model.Opacity = Convert.ToInt32(key.GetValue("dmd_opacity"));
            if (valueList.Contains("dmd_border"))
                model.Border = Convert.ToBoolean(key.GetValue("dmd_border"));
            if (valueList.Contains("dmd_title"))
                model.Title = Convert.ToBoolean(key.GetValue("dmd_title"));
            if (valueList.Contains("scanlines"))
                model.Scanlines = Convert.ToBoolean(key.GetValue("scanlines"));
            if (valueList.Contains("ddraw"))
                model.DirectDraw = Convert.ToBoolean(key.GetValue("ddraw"));
            if (valueList.Contains("showwindmd"))
                model.ShowVPinMameDmd = Convert.ToBoolean(key.GetValue("showwindmd"));
            if (valueList.Contains("direct3d"))
                model.Direct3D = Convert.ToBoolean(key.GetValue("direct3d"));
            if (valueList.Contains("at91jit"))
                model.At91jit = Convert.ToBoolean(key.GetValue("at91jit"));
            if (valueList.Contains("showpindmd"))
                model.ExternalDmdDevice = Convert.ToBoolean(key.GetValue("showpindmd"));
            if (valueList.Contains("dmd_height"))
                model.Height = Convert.ToInt32(key.GetValue("dmd_height"));
            if (valueList.Contains("dmd_width"))
                model.Width = Convert.ToInt32(key.GetValue("dmd_width"));
            if (valueList.Contains("dmd_pos_x"))
                model.OffsetX = Convert.ToInt32(key.GetValue("dmd_pos_x"));
            if (valueList.Contains("dmd_pos_y"))
                model.OffsetY = Convert.ToInt32(key.GetValue("dmd_pos_y"));
            if (valueList.Contains("dmd_perc0"))
                model.IntensityPerc0 = Convert.ToInt32(key.GetValue("dmd_perc0"));
            if (valueList.Contains("dmd_perc33"))
                model.IntensityPerc33 = Convert.ToInt32(key.GetValue("dmd_perc33"));
            if (valueList.Contains("dmd_perc66"))
                model.IntensityPerc66 = Convert.ToInt32(key.GetValue("dmd_perc66"));
            if (valueList.Contains("dmd_colorize"))
                model.Colorize = Convert.ToBoolean(key.GetValue("dmd_colorize"));
            if (valueList.Contains("cabinet_mode"))
                model.CabinetMode = Convert.ToBoolean(key.GetValue("cabinet_mode"));
            if (valueList.Contains("ignore_rom_crc"))
                model.IgnoreRomCrc = Convert.ToBoolean(key.GetValue("ignore_rom_crc"));
            if (valueList.Contains("rol"))
                model.RotateLeft = Convert.ToBoolean(key.GetValue("rol"));
            if (valueList.Contains("ror"))
                model.RotateRight = Convert.ToBoolean(key.GetValue("ror"));
            if (valueList.Contains("flipy"))
                model.FlipY = Convert.ToBoolean(key.GetValue("flipy"));
            if (valueList.Contains("flipx"))
                model.FlipX = Convert.ToBoolean(key.GetValue("flipx"));
            if (valueList.Contains("synclevel"))
                model.SyncLevel = Convert.ToInt32(key.GetValue("synclevel"));
            if (valueList.Contains("resampling_quality"))
                model.ResamplingQuality = Convert.ToBoolean(key.GetValue("resampling_quality"));
            if (valueList.Contains("dmd_doublesize"))
                model.DoubleDisplaySize = Convert.ToBoolean(key.GetValue("dmd_doublesize"));
            if (valueList.Contains("fastframes"))
                model.FastFrames = Convert.ToInt32(key.GetValue("fastframes"));
            if (valueList.Contains("samplerate"))
                model.SampleRate = Convert.ToInt32(key.GetValue("samplerate"));
            if (valueList.Contains("dmd_compact"))
                model.CompactMode = Convert.ToBoolean(key.GetValue("dmd_compact"));
            if (valueList.Contains("sound_mode"))
                model.SoundMode = Convert.ToInt32(key.GetValue("sound_mode"));
            if (valueList.Contains("samples"))
                model.UseSamples = Convert.ToBoolean(key.GetValue("samples"));
            if (valueList.Contains("sound"))
                model.EnableSound = Convert.ToBoolean(key.GetValue("sound"));
            if (valueList.Contains("dmd_red"))
                model.Red = Convert.ToInt32(key.GetValue("dmd_red"));
            if (valueList.Contains("dmd_green"))
                model.Green = Convert.ToInt32(key.GetValue("dmd_green"));
            if (valueList.Contains("dmd_blue"))
                model.Blue = Convert.ToInt32(key.GetValue("dmd_blue"));
            return model;
        }

        public void SaveRomModelToRegsitry(VpinMameRomSetting setting)
        {
            if (setting == null)
                return;

            using (var key = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Freeware")?.OpenSubKey("Visual PinMame")?.OpenSubKey(setting.RomName, true))
            {
                key.SetOrDeleteKeyBoolAsInt("antialias", setting.EnableAntiAlias);
                key.SetOrDeleteKeyBoolAsInt("cheat", setting.SkipStartup);
                key.SetOrDeleteKeyInt("dmd_antialias", setting.AntiAliasPercentage);
                key.SetOrDeleteKeyInt("dmd_opacity", setting.Opacity);
                key.SetOrDeleteKeyBoolAsInt("dmd_border", setting.Border);
                key.SetOrDeleteKeyBoolAsInt("dmd_title", setting.Title);
                key.SetOrDeleteKeyBoolAsInt("scanlines", setting.Scanlines);
                key.SetOrDeleteKeyBoolAsInt("ddraw", setting.DirectDraw);
                key.SetOrDeleteKeyBoolAsInt("showwindmd", setting.ShowVPinMameDmd);
                key.SetOrDeleteKeyBoolAsInt("direct3d", setting.Direct3D);
                key.SetOrDeleteKeyBoolAsInt("at91jit", setting.At91jit);
                key.SetOrDeleteKeyBoolAsInt("showpindmd", setting.ExternalDmdDevice);
                key.SetOrDeleteKeyInt("dmd_height", setting.Height);
                key.SetOrDeleteKeyInt("dmd_width", setting.Width);
                key.SetOrDeleteKeyInt("dmd_pos_x", setting.OffsetX);
                key.SetOrDeleteKeyInt("dmd_pos_y", setting.OffsetY);
                key.SetOrDeleteKeyInt("dmd_perc0", setting.IntensityPerc0);
                key.SetOrDeleteKeyInt("dmd_perc33", setting.IntensityPerc33);
                key.SetOrDeleteKeyInt("dmd_perc66", setting.IntensityPerc66);
                key.SetOrDeleteKeyBoolAsInt("dmd_colorize", setting.Colorize);
                key.SetOrDeleteKeyBoolAsInt("cabinet_mode", setting.CabinetMode);
                key.SetOrDeleteKeyBoolAsInt("ignore_rom_crc", setting.IgnoreRomCrc);
                key.SetOrDeleteKeyBoolAsInt("rol", setting.RotateLeft);
                key.SetOrDeleteKeyBoolAsInt("ror", setting.RotateRight);
                key.SetOrDeleteKeyBoolAsInt("flipy", setting.FlipY);
                key.SetOrDeleteKeyBoolAsInt("flipx", setting.FlipX);
                key.SetOrDeleteKeyInt("synclevel", setting.SyncLevel);
                key.SetOrDeleteKeyBoolAsInt("resampling_quality", setting.ResamplingQuality);
                key.SetOrDeleteKeyBoolAsInt("dmd_doublesize", setting.DoubleDisplaySize);
                key.SetOrDeleteKeyInt("fastframes", setting.FastFrames);
                key.SetOrDeleteKeyInt("samplerate", setting.SampleRate);
                key.SetOrDeleteKeyBoolAsInt("dmd_compact", setting.CompactMode);
                key.SetOrDeleteKeyInt("sound_mode", setting.SoundMode);
                key.SetOrDeleteKeyBoolAsInt("samples", setting.UseSamples);
                key.SetOrDeleteKeyBoolAsInt("sound", setting.EnableSound);
                key.SetOrDeleteKeyInt("dmd_red", setting.Red);
                key.SetOrDeleteKeyInt("dmd_green", setting.Green);
                key.SetOrDeleteKeyInt("dmd_blue", setting.Blue);
                key.Close();
            }
        }
    }
}
