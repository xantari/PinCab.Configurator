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

        public PinballXUtil(string iniFilePath) {
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
            using(var ms = new MemoryStream())
            {
                using(var sw = new StreamWriter(ms))
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

        public int GetDmdMonitorNumber()
        {
            return Convert.ToInt32(_data["DMD"]["monitor"]);
        }

        public void SetMonitorNumber(int monitorNumber)
        {
            _data["DMD"]["monitor"] = monitorNumber.ToString();
        }

        public RegionRectangle GetDmdRegionRectangle()
        {
            var regionRectangle = new RegionRectangle();
            regionRectangle.RegionDisplayHeight = Convert.ToInt32(_data["DMD"]["height"]);
            regionRectangle.RegionDisplayWidth = Convert.ToInt32(_data["DMD"]["width"]);
            regionRectangle.RegionOffsetX = Convert.ToInt32(_data["DMD"]["x"]);
            regionRectangle.RegionOffsetY = Convert.ToInt32(_data["DMD"]["y"]);

            return regionRectangle;
        }

        public void SetDmdRegionRectangle(RegionRectangle regionRectangle)
        {
            _data["DMD"]["height"] = regionRectangle.RegionDisplayHeight.ToString();
            _data["DMD"]["width"] = regionRectangle.RegionDisplayWidth.ToString();
            _data["DMD"]["x"] = regionRectangle.RegionOffsetX.ToString();
            _data["DMD"]["y"] = regionRectangle.RegionOffsetY.ToString();
        }

        public ValidationResult Validate(RegionRectangle dmdRegionRectangle, int monitorNumber)
        {
            var result = new ValidationResult();

            var pinballXrectangle = GetDmdRegionRectangle();

            if (GetDmdMonitorNumber() != monitorNumber)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Monitor Number does not match. Expected: {GetDmdMonitorNumber()} Actual: {monitorNumber}", MessageLevel.Error));
            }

            if (pinballXrectangle.RegionDisplayHeight != dmdRegionRectangle.RegionDisplayHeight)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Region Display Height does not match. Expected: {dmdRegionRectangle.RegionDisplayHeight} Actual: {pinballXrectangle.RegionDisplayHeight}", MessageLevel.Error));
            }

            if (pinballXrectangle.RegionDisplayWidth != dmdRegionRectangle.RegionDisplayWidth)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Region Display Width does not match. Expected: {dmdRegionRectangle.RegionDisplayWidth} Actual: {pinballXrectangle.RegionDisplayWidth}", MessageLevel.Error));
            }

            if (pinballXrectangle.RegionOffsetX != dmdRegionRectangle.RegionOffsetX)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Region Display X Offset does not match. Expected: {dmdRegionRectangle.RegionOffsetX} Actual: {pinballXrectangle.RegionOffsetX}", MessageLevel.Error));
            }

            if (pinballXrectangle.RegionOffsetY != dmdRegionRectangle.RegionOffsetY)
            {
                result.IsValid = false;
                result.Messages.Add(new ValidationMessage
                    ($"Pinball X Region Display Y Offset does not match. Expected: {dmdRegionRectangle.RegionOffsetY} Actual: {pinballXrectangle.RegionOffsetY}", MessageLevel.Error));
            }

            return result;
        }
    }

}
