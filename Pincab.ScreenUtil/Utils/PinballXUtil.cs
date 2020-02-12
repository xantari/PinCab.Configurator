using IniParser;
using IniParser.Model;
using Pincab.ScreenUtil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil.Utils
{
    public class PinballXUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }

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
            File.Copy(_iniFilePath, currentFolder + $"{fileInfo.Name}_{DateTime.Now.ToString("MM-dd-yyyy_hhMMss")}");

            //Save the file
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    _parser.WriteData(sw, _data);
                }
                var text = System.Text.UnicodeEncoding.UTF8.GetString(ms.ToArray());
                //Post fixup (PinballX doesn't like spaces between "="'s signs
                text = text.Replace(" = ", "=").RemoveBlankLines("\r\n");
                File.WriteAllText(_iniFilePath, text, Encoding.Unicode);
            }
            //_parser.WriteFile(_iniFilePath, _data, Encoding.Unicode);
        }

        public int GetMonitorNumber(string section)
        {
            return Convert.ToInt32(_data[section]["monitor"]);
        }

        public void SetMonitorNumber(string section, int monitorNumber)
        {
            _data[section]["monitor"] = monitorNumber.ToString();
        }

        public RegionRectangle GetRegionRectangle(string section)
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_data[section]["height"]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_data[section]["width"]);
            regionRectangle.RegionOffsetX = Convert.ToInt32(_data[section]["x"]);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_data[section]["y"]);

            return regionRectangle;
        }

        public void SetRegionRectangle(string section, RegionRectangle regionRectangle)
        {
            _data[section]["height"] = regionRectangle.RegionDisplayHeight.ToString();
            _data[section]["width"] = regionRectangle.RegionDisplayWidth.ToString();
            _data[section]["x"] = regionRectangle.RegionOffsetX.ToString();
            _data[section]["y"] = regionRectangle.RegionOffsetY.ToString();
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            //Validate Playfield monitor number

            //Validate Backglass

            //Validate DMD
            var dmdResult = ValidateDmd(displayDetails);
            if (dmdResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(dmdResult.Messages);

            //Validate Topper

            //Validate Apron

            return result;
        }

        public ValidationResult ValidateDmd(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            var pinballXCurrentDmdRegion = GetRegionRectangle("DMD");

            var dmdDisplay = displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains("DMD"));
            var regionDmdRectangle = dmdDisplay?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains("DMD"));
            var dmdMonitorNumber = dmdDisplay.GetMonitorNumber();

            if (regionDmdRectangle != null)
            {
                if (GetMonitorNumber("DMD") != dmdMonitorNumber - 1)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X DMD Monitor Number does not match. Expected: {GetMonitorNumber("DMD")} Actual: {dmdMonitorNumber - 1}", MessageLevel.Error));
                }

                if (pinballXCurrentDmdRegion.RegionDisplayHeight != regionDmdRectangle.RegionDisplayHeight)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X Region Display Height does not match. Expected: {regionDmdRectangle.RegionDisplayHeight} Actual: {pinballXCurrentDmdRegion.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (pinballXCurrentDmdRegion.RegionDisplayWidth != regionDmdRectangle.RegionDisplayWidth)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X Region Display Width does not match. Expected: {regionDmdRectangle.RegionDisplayWidth} Actual: {pinballXCurrentDmdRegion.RegionDisplayWidth}", MessageLevel.Error));
                }

                if (pinballXCurrentDmdRegion.RegionOffsetX != regionDmdRectangle.RegionOffsetX)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X Region Display X Offset does not match. Expected: {regionDmdRectangle.RegionOffsetX} Actual: {pinballXCurrentDmdRegion.RegionOffsetX}", MessageLevel.Error));
                }

                if (pinballXCurrentDmdRegion.RegionOffsetY != regionDmdRectangle.RegionOffsetY)
                {
                    result.IsValid = false;
                    result.Messages.Add(new ValidationMessage
                        ($"Pinball X Region Display Y Offset does not match. Expected: {regionDmdRectangle.RegionOffsetY} Actual: {pinballXCurrentDmdRegion.RegionOffsetY}", MessageLevel.Error));
                }
            }
            else
            {
                result.Messages.Add(new ValidationMessage
                 ($"Pinball X: No DMD Region defined. Skipping...", MessageLevel.Information));
            }

            return result;
        }
    }

}
