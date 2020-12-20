using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    /// <summary>
    /// B2S Blackglass screenres.txt Util
    /// 
    /// Screenres.txt consists of 12 lines as follows:
    /// 1366 <-- Playfild screen X resolution (width)
    /// 768 <-- playfield screen Y resolution(height)
    /// 1280 <-- Backglass screen X resolution(width)
    /// 1024 <-- Backglass screen Y resolution(height)
    /// 2 <-- Display number for the backglass
    /// 0 <-- X offset for the backglass on the selected display(normally left at 0)
    /// 0 <-- Y offset for the backglass on the selected display(normally left at 0)
    /// 600 <-- Width of the DMD area in pixels
    /// 200 <-- Height of the DMD area in pixels
    /// 1280 <-- X position of the DMD area relative to the upper left corner of the backglass screen
    /// 100 <-- Y position of the DMD area relative to the upper left corner of the backglass screen
    /// 0 <-- Y-flip, flips the LED display uppside down. Used in P2K style cabs.
    /// 
    /// File must be saved with UTF-8 (no BOM) for it to read properly by B2S.
    /// </summary>
    public class B2sUtil
    {
        private string _screenResFilePath { get; set; }
        
        public const string ToolName = "B2S Screenres.txt";

        private List<string> _fileContentsArray { get; set; } = new List<string>();

        public B2sUtil(string screenResFilePath)
        {
            _screenResFilePath = screenResFilePath;
            if (File.Exists(screenResFilePath))
            {
                _fileContentsArray.AddRange(Regex.Split(File.ReadAllText(screenResFilePath), "\r\n")); //CRLF
            }
        }

        public B2sIni GetB2sIniModel()
        {
            if (_fileContentsArray.Count() >= 12)
            {
                var model = new B2sIni()
                {
                    PlayfieldWidth = Convert.ToInt32(_fileContentsArray[0]),
                    PlayfieldHeight = Convert.ToInt32(_fileContentsArray[1]),
                    BackglassWidth = Convert.ToInt32(_fileContentsArray[2]),
                    BackglassHeight = Convert.ToInt32(_fileContentsArray[3]),
                    BackglassDisplayNumber = Convert.ToInt32(_fileContentsArray[4]),
                    BackglassXOffset = Convert.ToInt32(_fileContentsArray[5]),
                    BackglassYOffset = Convert.ToInt32(_fileContentsArray[6]),
                    DMDWidth = Convert.ToInt32(_fileContentsArray[7]),
                    DMDHeight = Convert.ToInt32(_fileContentsArray[8]),
                    DMDXOffset = Convert.ToInt32(_fileContentsArray[9]),
                    DMDYOffset = Convert.ToInt32(_fileContentsArray[10]),
                    YFlip = Convert.ToInt32(_fileContentsArray[11])
                };
                return model;
            }
            Log.Information("Unable to find B2sIni file while trying to hydra the B2s Ini model");
            return null;
        }

        public void SaveB2sIniModel(B2sIni model)
        {
            if (model == null)
                return;

            _fileContentsArray[0] = model.PlayfieldWidth.ToString();
            _fileContentsArray[1] = model.PlayfieldHeight.ToString();
            _fileContentsArray[2] = model.BackglassWidth.ToString();
            _fileContentsArray[3] = model.BackglassHeight.ToString();
            _fileContentsArray[4] = model.BackglassDisplayNumber.ToString();
            _fileContentsArray[5] = model.BackglassXOffset.ToString();
            _fileContentsArray[6] = model.BackglassYOffset.ToString();
            _fileContentsArray[7] = model.DMDWidth.ToString();
            _fileContentsArray[8] = model.DMDHeight.ToString();
            _fileContentsArray[9] = model.DMDXOffset.ToString();
            _fileContentsArray[10] = model.DMDYOffset.ToString();
            _fileContentsArray[11] = model.YFlip.ToString();
            SaveSettings();
        }

        public void SaveSettings()
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\B2S\\";
            var fileInfo = new FileInfo(_screenResFilePath);
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}";
            File.Copy(_screenResFilePath, filePath);

            Log.Information("{ToolName}: Wrote settings backup: {location}", ToolName, filePath);

            //Save the file
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(_screenResFilePath, string.Join("\r\n", _fileContentsArray), utf8WithoutBom);
        }

        /// <summary>
        /// Backglass Monitor Number
        /// </summary>
        /// <returns></returns>
        public int GetMonitorNumber()
        {
            return Convert.ToInt32(_fileContentsArray[4]);
        }

        /// <summary>
        /// Set Backglass monitor number
        /// </summary>
        /// <param name="monitorNumber"></param>
        public void SetMonitorNumber(int monitorNumber)
        {
            _fileContentsArray[4] = monitorNumber.ToString();
        }

        public RegionRectangle GetBackglassRegionRectangle()
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_fileContentsArray[3]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_fileContentsArray[2]);
            regionRectangle.RegionOffsetX = Convert.ToInt32(_fileContentsArray[5]);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_fileContentsArray[6]);

            return regionRectangle;
        }

        public void SetBackglassRegionRectangle(DisplayDetail display, RegionRectangle regionRectangle)
        {
            _fileContentsArray[3] = regionRectangle.RegionDisplayHeight.ToString();
            _fileContentsArray[2] = regionRectangle.RegionDisplayWidth.ToString();
            _fileContentsArray[5] = regionRectangle.RegionOffsetX.ToString();
            _fileContentsArray[6] = regionRectangle.RegionOffsetY.ToString();
        }

        public RegionRectangle GetDMDRegionRectangle()
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_fileContentsArray[8]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_fileContentsArray[7]);
            regionRectangle.RegionOffsetX = Convert.ToInt32(_fileContentsArray[9]);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_fileContentsArray[10]);

            return regionRectangle;
        }

        public void SetDMDRegionRectangle(DisplayDetail display, RegionRectangle regionRectangle)
        {
            _fileContentsArray[8] = regionRectangle.RegionDisplayHeight.ToString();
            _fileContentsArray[7] = regionRectangle.RegionDisplayWidth.ToString();
            _fileContentsArray[9] = regionRectangle.RegionOffsetX.ToString();
            _fileContentsArray[10] = regionRectangle.RegionOffsetY.ToString();
        }

        public RegionRectangle GetPlayfieldRegionRectangle()
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_fileContentsArray[1]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_fileContentsArray[0]);

            return regionRectangle;
        }

        public void SetPlayfieldRegionRectangle(DisplayDetail display, RegionRectangle regionRectangle)
        {
            _fileContentsArray[1] = regionRectangle.RegionDisplayHeight.ToString();
            _fileContentsArray[0] = regionRectangle.RegionDisplayWidth.ToString();
        }

        public void SetDisplayDetails(string section, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == section.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.ToLower().Contains(section.ToLower()));

            if (regionRectangle != null)
            {
                if (section == Consts.Playfield)
                    SetPlayfieldRegionRectangle(display, regionRectangle);
                if (section == Consts.DMD)
                    SetDMDRegionRectangle(display, regionRectangle);
                if (section == Consts.Backglass)
                {
                    SetBackglassRegionRectangle(display, regionRectangle);
                    SetMonitorNumber(display.GetMonitorNumber());
                }
            }
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var playfield = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.Playfield.ToLower()));
            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));
            var backglass = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.Backglass.ToLower()));

            if (!File.Exists(_screenResFilePath))
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find B2S screenres.txt file. Have you defined it's location in settings yet?", MessageLevel.Error));
            }

            if (playfield == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: Playfield not yet defined.", MessageLevel.Error));
            if (backglass == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: Backglass not yet defined.", MessageLevel.Error));
            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdRegionFromScreenResTxt = GetDMDRegionRectangle();
            var playfieldRegionFromScreenResTxt = GetPlayfieldRegionRectangle();
            var backglassRegionFromScreenResTxt = GetBackglassRegionRectangle();

            if (dmdRegionFromScreenResTxt != null)
            {
                var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

                if (dmdRegionFromScreenResTxt.RegionDisplayHeight != dmdRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Height does not match. Expected: {dmdRectangle.RegionDisplayHeight} Actual: {dmdRegionFromScreenResTxt.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (dmdRegionFromScreenResTxt.RegionDisplayWidth != dmdRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Width does not match. Expected: {dmdRectangle.RegionDisplayWidth} Actual: {dmdRegionFromScreenResTxt.RegionDisplayWidth}", MessageLevel.Error));
                }

                //var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
                if (dmdRegionFromScreenResTxt.RegionOffsetX != dmdRectangle.RegionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display X Offset does not match. Expected: {dmdRectangle.RegionOffsetX} Actual: {dmdRegionFromScreenResTxt.RegionOffsetX}", MessageLevel.Error));
                }

                //var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);
                if (dmdRegionFromScreenResTxt.RegionOffsetY != dmdRectangle.RegionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {dmdRectangle.RegionLabel} Region Display Y Offset does not match. Expected: {dmdRectangle.RegionOffsetY} Actual: {dmdRegionFromScreenResTxt.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"{ToolName}: No DMD Region defined. Skipping...", MessageLevel.Information));
            }

            if (backglassRegionFromScreenResTxt != null)
            {
                var backglassRectangle = backglass?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.Backglass));

                if (backglassRegionFromScreenResTxt.RegionDisplayHeight != backglassRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {backglassRectangle.RegionLabel} Region Display Height does not match. Expected: {backglassRectangle.RegionDisplayHeight} Actual: {backglassRegionFromScreenResTxt.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (backglassRegionFromScreenResTxt.RegionDisplayWidth != backglassRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {backglassRectangle.RegionLabel} Region Display Width does not match. Expected: {backglassRectangle.RegionDisplayWidth} Actual: {backglassRegionFromScreenResTxt.RegionDisplayWidth}", MessageLevel.Error));
                }

                //var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
                if (backglassRegionFromScreenResTxt.RegionOffsetX != backglassRectangle.RegionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {backglassRectangle.RegionLabel} Region Display X Offset does not match. Expected: {backglassRectangle.RegionOffsetX} Actual: {backglassRegionFromScreenResTxt.RegionOffsetX}", MessageLevel.Error));
                }

                //var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);
                if (backglassRegionFromScreenResTxt.RegionOffsetY != backglassRectangle.RegionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {backglassRectangle.RegionLabel} Region Display Y Offset does not match. Expected: {backglassRectangle.RegionOffsetY} Actual: {backglassRegionFromScreenResTxt.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"{ToolName}: No Backglass Region defined. Skipping...", MessageLevel.Information));
            }

            if (playfieldRegionFromScreenResTxt != null)
            {
                var playFieldRectangle = playfield?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.Playfield));

                if (playfieldRegionFromScreenResTxt.RegionDisplayHeight != playFieldRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {playFieldRectangle.RegionLabel} Region Display Height does not match. Expected: {playFieldRectangle.RegionDisplayHeight} Actual: {playfieldRegionFromScreenResTxt.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (playfieldRegionFromScreenResTxt.RegionDisplayWidth != playFieldRectangle.RegionDisplayWidth)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {playFieldRectangle.RegionLabel} Region Display Width does not match. Expected: {playFieldRectangle.RegionDisplayWidth} Actual: {playfieldRegionFromScreenResTxt.RegionDisplayWidth}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"{ToolName}: No Playfield Region defined. Skipping...", MessageLevel.Information));
            }

            if (result.Messages.HasAnyErrors())
                result.IsValid = false;

            result.Messages.Add(new ValidationMessage($"{ToolName}: Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }

}
