using IniParser;
using IniParser.Model;
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
    public class PinballXUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }

        private const string monitor = "monitor";
        private const string height = "height";
        private const string width = "width";
        private const string x = "x";
        private const string y = "y";

        public const string Display = "Display"; //Actually the playfield setting

        public PinballXUtil(string iniFilePath)
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
            string filePath = $"{fileInfo.Name}_{DateTime.Now.ToString("MM-dd-yyyy_hhMMss")}";
            File.Copy(_iniFilePath, currentFolder + filePath);

            Log.Information("Wrote future dmd backup: {location}", filePath);

            //Save the file
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    _parser.WriteData(sw, _data);
                }
                var text = Encoding.UTF8.GetString(ms.ToArray());
                //Post fixup (PinballX doesn't like spaces between "="'s signs
                text = text.Replace(" = ", "=").RemoveBlankLines("\r\n");
                File.WriteAllText(_iniFilePath, text, Encoding.Unicode);
            }
            //_parser.WriteFile(_iniFilePath, _data, Encoding.Unicode);
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
                SetMonitorNumber(section, display.GetMonitorNumber() - 1); //PinballX stores monitor #'s starting at 0
            }
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            //Validate Playfield monitor number
            var playFieldResult = ValidatePlayfield(displayDetails);
            if (playFieldResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(playFieldResult.Messages);

            //Validate Backglass
            var backglassResult = ValidateRegion(Consts.Backglass, displayDetails);
            if (backglassResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(backglassResult.Messages);

            //Validate DMD
            var dmdResult = ValidateRegion(Consts.DMD, displayDetails);
            if (dmdResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(dmdResult.Messages);

            //Validate Topper
            var topperResult = ValidateRegion(Consts.Topper, displayDetails);
            if (topperResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(topperResult.Messages);

            //Validate Apron
            var apronResult = ValidateRegion(Consts.Apron, displayDetails);
            if (apronResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(apronResult.Messages);

            return result;
        }

        public ValidationResult ValidatePlayfield(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            var playfieldDisplay = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Playfield));
            var playfieldMonitorNumber = playfieldDisplay.GetMonitorNumber() - 1;
            if (playfieldMonitorNumber != GetMonitorNumber(Display)) //Pinball X calls the playfield "Display" in the .ini file
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Playfield Monitor Number does not match. Expected: {GetMonitorNumber(Display)} Actual: {playfieldMonitorNumber}", MessageLevel.Error));
            }

            result.Messages.Add(new ValidationMessage($"Pinball X: Playfield Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }

        public ValidationResult ValidateRegion(string displayName, List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            var pinballXCurrentRegion = GetRegionRectangle(displayName);

            var display = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(displayName));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(displayName));
            var monitorNumber = display?.GetMonitorNumber() - 1;

            if (regionRectangle != null)
            {
                if (GetMonitorNumber(displayName) != monitorNumber)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X {displayName} Monitor Number does not match. Expected: {GetMonitorNumber(displayName)} Actual: {monitorNumber}", MessageLevel.Error));
                }

                if (pinballXCurrentRegion.RegionDisplayHeight != regionRectangle.RegionDisplayHeight)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X {displayName} Region Display Height does not match. Expected: {regionRectangle.RegionDisplayHeight} Actual: {pinballXCurrentRegion.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (pinballXCurrentRegion.RegionDisplayWidth != regionRectangle.RegionDisplayWidth)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X {displayName} Region Display Width does not match. Expected: {regionRectangle.RegionDisplayWidth} Actual: {pinballXCurrentRegion.RegionDisplayWidth}", MessageLevel.Error));
                }

                if (pinballXCurrentRegion.RegionOffsetX != regionRectangle.RegionOffsetX)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X {displayName} Region Display X Offset does not match. Expected: {regionRectangle.RegionOffsetX} Actual: {pinballXCurrentRegion.RegionOffsetX}", MessageLevel.Error));
                }

                if (pinballXCurrentRegion.RegionOffsetY != regionRectangle.RegionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X {displayName} Region Display Y Offset does not match. Expected: {regionRectangle.RegionOffsetY} Actual: {pinballXCurrentRegion.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"Pinball X: No {displayName} Region defined. Skipping...", MessageLevel.Information));
            }

            result.Messages.Add(new ValidationMessage($"Pinball X: {displayName} Validation done. Issues found: {!result.IsValid}", MessageLevel.Information));

            return result;
        }
    }

}
