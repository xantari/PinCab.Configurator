using IniParser;
using IniParser.Model;
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
    /// FutureDMD Util
    /// FutureDMD stores it's X/Y positions as virtual desktop positions
    /// </summary>
    public class FutureDmdUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }

        public const string ToolName = "FutureDMD";

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
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\FutureDMD\\";
            var fileInfo = new FileInfo(_iniFilePath);
            Directory.CreateDirectory(currentFolder);
            string filePath = currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_hhMMss")}";
            File.Copy(_iniFilePath, filePath);

            Log.Information("{ToolName}: Wrote settings backup: {location}", ToolName, filePath);

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
                Encoding encoding = new ASCIIEncoding();
                File.WriteAllText(_iniFilePath, text, encoding);
            }
        }

        public int GetMonitorNumber(string section)
        {
            var val = _data[section].FirstOrDefault(p => p.KeyName.ToLower() == monitor.ToLower());
            return Convert.ToInt32(val.Value);
        }

        public void SetMonitorNumber(string section, int monitorNumber)
        {
            var val = _data[section].FirstOrDefault(p => p.KeyName.ToLower() == monitor.ToLower());
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

        public void SetRegionRectangle(string section, DisplayDetail display, RegionRectangle regionRectangle)
        {
            _data[section][height] = regionRectangle.RegionDisplayHeight.ToString();
            _data[section][width] = regionRectangle.RegionDisplayWidth.ToString();
            //Future DMD uses virtual desktop space for it's X/Y calculations
            _data[section][x] = display.VirtualResolutionOffsetX(regionRectangle).ToString();
            _data[section][y] = display.VirtualResolutionOffsetY(regionRectangle).ToString();
        }

        public void SetDisplayDetails(string section, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == section.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.ToLower().Contains(section.ToLower()));

            if (regionRectangle != null)
            {  //FutureDMD settings store in a single section called [default]
                SetRegionRectangle("default", display, regionRectangle);
                SetMonitorNumber("default", display.GetMonitorNumber() - 1); //Future stores monitor #'s starting at 0
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

            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == displayName.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(displayName));
            var monitorNumber = display?.GetMonitorNumber() - 1;

            if (regionRectangle != null)
            {
                if (GetMonitorNumber("default") != monitorNumber)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Monitor Number does not match. Expected: {GetMonitorNumber("default")} Actual: {monitorNumber}", MessageLevel.Error));
                }
                
                if (futureDmdRegionFromIni.RegionDisplayHeight != regionRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Height does not match. Expected: {regionRectangle.RegionDisplayHeight} Actual: {futureDmdRegionFromIni.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (futureDmdRegionFromIni.RegionDisplayWidth != regionRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Width does not match. Expected: {regionRectangle.RegionDisplayWidth} Actual: {futureDmdRegionFromIni.RegionDisplayWidth}", MessageLevel.Error));
                }

                var regionOffsetX = display.VirtualResolutionOffsetX(regionRectangle);
                if (futureDmdRegionFromIni.RegionOffsetX != regionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {futureDmdRegionFromIni.RegionOffsetX}", MessageLevel.Error));
                }

                var regionOffsetY = display.VirtualResolutionOffsetY(regionRectangle);
                if (futureDmdRegionFromIni.RegionOffsetY != regionOffsetY)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {futureDmdRegionFromIni.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"{ToolName}: No {displayName} Region defined. Skipping...", MessageLevel.Information));
            }

            if (result.Messages.HasAnyErrors())
                result.IsValid = false;

            result.Messages.Add(new ValidationMessage($"{ToolName}: {displayName} Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }

}
