using IniParser;
using IniParser.Model;
using PinCab.ScreenUtil.Models;
using Serilog;
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
    /// </summary>
    public class B2sUtil
    {
        private string _screenResFilePath { get; set; }
        
        private const string ToolName = "B2S Screenres.txt";

        private List<string> _fileContentsArray { get; set; } = new List<string>();

        public B2sUtil(string screenResFilePath)
        {
            _screenResFilePath = screenResFilePath;
            if (File.Exists(screenResFilePath))
            {
                _fileContentsArray.AddRange(Regex.Split(File.ReadAllText(screenResFilePath), "\r\n")); //CRLF
            }
        }

        public void SaveSettings()
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\";
            var fileInfo = new FileInfo(_screenResFilePath);
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("MM-dd-yyyy_hhMMss")}";
            File.Copy(_screenResFilePath, filePath);

            Log.Information("{ToolName} Wrote B2S screenres.txt backup: {location}", ToolName, filePath);

            //Save the file
            File.WriteAllText(_screenResFilePath, string.Join("\r\n", _fileContentsArray), Encoding.UTF8);
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
            _fileContentsArray[5] = display.VirtualResolutionOffsetX(regionRectangle).ToString();
            _fileContentsArray[6] = display.VirtualResolutionOffsetY(regionRectangle).ToString();
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
            _fileContentsArray[9] = display.VirtualResolutionOffsetX(regionRectangle).ToString();
            _fileContentsArray[10] = display.VirtualResolutionOffsetY(regionRectangle).ToString();
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

        public void SetDisplayDetails(List<DisplayDetail> displayDetails)
        {
            var playfield = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Playfield));
            var dmd = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.DMD));
            var backglass = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Backglass));

            //var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(section));

            //if (regionRectangle != null)
            //{  
            //    SetRegionRectangle("default", display, regionRectangle);
            //    SetMonitorNumber("default", display.GetMonitorNumber() - 1); //Future stores monitor #'s starting at 0
            //}
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var playfield = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Playfield));
            var dmd = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.DMD));
            var backglass = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Backglass));

            if (!File.Exists(_screenResFilePath))
            {
                result.Messages.Add(new ValidationMessage
                    ($"{ToolName}: Unable to find B2S screenres.txt file. Have you defined it's location in settings yet?", MessageLevel.Error));
                result.IsValid = false;
            }

            if (!result.IsValid) //Don't proceed forward with validations if they haven't defined the minimum necessary items
                return result;

            var dmdRegionFromScreenResTxt = GetDMDRegionRectangle();
            var playfieldRegionFromScreenResTxt = GetPlayfieldRegionRectangle();
            var backglassRegionFromScreenResTxt = GetBackglassRegionRectangle();

            if (playfield == null)
            {
                result.Messages.Add(new ValidationMessage($"{ToolName}: Playfield not yet defined.", MessageLevel.Error));
                result.IsValid = false;
            }
            if (backglass == null)
            {
                result.Messages.Add(new ValidationMessage($"{ToolName}: Backglass not yet defined.", MessageLevel.Error));
                result.IsValid = false;
            }
            if (dmd == null)
            {
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));
                result.IsValid = false;
            }

            if (!result.IsValid) //Don't proceed forward with validations if they haven't defined the minimum necessary items
                return result;


            //if (regionRectangle != null)
            //{
            //    if (GetMonitorNumber("default") != monitorNumber)
            //    {
            //        result.IsValid = false;
            //        result.Messages.Add(new ValidationMessage
            //            ($"FutureDMD {displayName} Monitor Number does not match. Expected: {GetMonitorNumber("default")} Actual: {monitorNumber}", MessageLevel.Error));
            //    }

            //    if (futureDmdRegionFromIni.RegionDisplayHeight != regionRectangle.RegionDisplayHeight)
            //    {
            //        result.IsValid = false;
            //        result.Messages.Add(new ValidationMessage
            //            ($"FutureDMD {displayName} Region Display Height does not match. Expected: {regionRectangle.RegionDisplayHeight} Actual: {futureDmdRegionFromIni.RegionDisplayHeight}", MessageLevel.Error));
            //    }

            //    if (futureDmdRegionFromIni.RegionDisplayWidth != regionRectangle.RegionDisplayWidth)
            //    {
            //        result.IsValid = false;
            //        result.Messages.Add(new ValidationMessage
            //            ($"FutureDMD {displayName} Region Display Width does not match. Expected: {regionRectangle.RegionDisplayWidth} Actual: {futureDmdRegionFromIni.RegionDisplayWidth}", MessageLevel.Error));
            //    }

            //    var regionOffsetX = display.VirtualResolutionOffsetX(regionRectangle);
            //    if (futureDmdRegionFromIni.RegionOffsetX != regionOffsetX)
            //    {
            //        result.IsValid = false;
            //        result.Messages.Add(new ValidationMessage
            //            ($"FutureDMD {displayName} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {futureDmdRegionFromIni.RegionOffsetX}", MessageLevel.Error));
            //    }

            //    var regionOffsetY = display.VirtualResolutionOffsetY(regionRectangle);
            //    if (futureDmdRegionFromIni.RegionOffsetY != regionOffsetY)
            //    {
            //        result.IsValid = false;
            //        result.Messages.Add(new ValidationMessage
            //            ($"FutureDMD {displayName} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {futureDmdRegionFromIni.RegionOffsetY}", MessageLevel.Error));
            //    }
            //}
            //else
            //{
            //    result.Messages.Add(new ValidationMessage
            //     ($"FutureDMD: No {displayName} Region defined. Skipping...", MessageLevel.Information));
            //}

            //result.Messages.Add(new ValidationMessage($"FutureDMD: {displayName} Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }

}
