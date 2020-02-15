using IniParser;
using IniParser.Model;
using PinCab.ScreenUtil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    /// <summary>
    /// FutureDMD Util
    /// FutureDMD stores it's X/Y positions as virtual desktop positions
    /// </summary>
    public class FutureDmdUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }

        private const string monitor = "PosScreen"; //0 based screen #
        private const string height = "SizeH";
        private const string width = "SizeW";
        private const string x = "PosX";
        private const string y = "PosY";

        public FutureDmdUtil(string iniFilePath)
        {
            _iniFilePath = iniFilePath;
            _parser = new FileIniDataParser();
            _data = _parser.ReadFile(iniFilePath);
        }

        public void SaveSettings()
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\";
            var fileInfo = new FileInfo(_iniFilePath);
            Directory.CreateDirectory(currentFolder);
            File.Copy(_iniFilePath, currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("MM-dd-yyyy_hhMMss")}");

            //Save the file
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    _parser.WriteData(sw, _data);
                }
                var text = Encoding.UTF8.GetString(ms.ToArray());
                //Post fixup (FutureDMD doesn't like spaces between "="'s signs
                text = text.Replace(" = ", "=").RemoveBlankLines("\r\n");
                File.WriteAllText(_iniFilePath, text, Encoding.Unicode);
            }
        }

        public int GetMonitorNumber(string section)
        {
            var val = _data[section].FirstOrDefault(p => p.KeyName.ToLower() == monitor.ToLower());
            return Convert.ToInt32(val.Value);
        }

        public void SetMonitorNumber(string section, int monitorNumber)
        {
            var val = _data[section].FirstOrDefault(p => p.KeyName.ToLower() == monitor);
            val.Value = monitorNumber.ToString();
        }

        public RegionRectangle GetRegionRectangle(string section)
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_data[section][height]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_data[section][width]);
            regionRectangle.RegionOffsetX = Convert.ToInt32(_data[section][x]);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_data[section][y]);

            return regionRectangle;
        }

        public void SetRegionRectangle(string section, RegionRectangle regionRectangle)
        {
            _data[section][height] = regionRectangle.RegionDisplayHeight.ToString();
            _data[section][width] = regionRectangle.RegionDisplayWidth.ToString();
            _data[section][x] = regionRectangle.RegionOffsetX.ToString();
            _data[section][y] = regionRectangle.RegionOffsetY.ToString();
        }

        public void SetDisplayDetails(string section, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(section));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(section));

            if (regionRectangle != null)
            {
                SetRegionRectangle(section, regionRectangle);
                SetMonitorNumber(section, display.GetMonitorNumber() - 1); //Future stores monitor #'s starting at 0
            }
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            //Validate DMD Position
            var dmdRegion = ValidateRegion(Consts.DMD, displayDetails);
            if (dmdRegion.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(dmdRegion.Messages);

            return result;
        }

        public ValidationResult ValidateRegion(string displayName, List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            var futureDmdRegionFromIni = GetRegionRectangle("default");

            var display = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(displayName));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(displayName));
            var monitorNumber = display?.GetMonitorNumber() - 1;

            if (regionRectangle != null)
            {
                if (GetMonitorNumber("default") != monitorNumber)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"FutureDMD {displayName} Monitor Number does not match. Expected: {GetMonitorNumber("default")} Actual: {monitorNumber}", MessageLevel.Error));
                }
                
                if (futureDmdRegionFromIni.RegionDisplayHeight != regionRectangle.RegionDisplayHeight)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"FutureDMD {displayName} Region Display Height does not match. Expected: {regionRectangle.RegionDisplayHeight} Actual: {futureDmdRegionFromIni.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (futureDmdRegionFromIni.RegionDisplayWidth != regionRectangle.RegionDisplayWidth)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"FutureDMD {displayName} Region Display Width does not match. Expected: {regionRectangle.RegionDisplayWidth} Actual: {futureDmdRegionFromIni.RegionDisplayWidth}", MessageLevel.Error));
                }

                var regionOffsetX = display.VirtualResolutionOffsetX(regionRectangle);
                if (futureDmdRegionFromIni.RegionOffsetX != regionOffsetX)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"FutureDMD {displayName} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {futureDmdRegionFromIni.RegionOffsetX}", MessageLevel.Error));
                }

                var regionOffsetY = display.VirtualResolutionOffsetY(regionRectangle);
                if (futureDmdRegionFromIni.RegionOffsetY != regionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"FutureDMD {displayName} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {futureDmdRegionFromIni.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"FutureDMD: No {displayName} Region defined. Skipping...", MessageLevel.Information));
            }

            result.Messages.Add(new ValidationMessage($"FutureDMD: {displayName} Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }

}
