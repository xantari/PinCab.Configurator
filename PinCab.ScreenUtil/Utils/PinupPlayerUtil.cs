using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
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
    public class PinupPlayerUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }
        private List<PinupPlayerSetting> _settings { get; set; }

        public const string ToolName = "PinupPlayer";

        private const string height = "ScreenHeight";
        private const string width = "ScreenWidth";
        private const string x = "ScreenXPos";
        private const string y = "ScreenYPos";

        public PinupPlayerUtil(string iniFilePath)
        {
            _iniFilePath = iniFilePath;
            var config = new IniParserConfiguration();
            config.CaseInsensitive = true;
            var parser = new IniDataParser(config);
            _parser = new FileIniDataParser(parser);
            _data = _parser.ReadFile(iniFilePath);
            _settings = new List<PinupPlayerSetting>();
        }

        public void SaveSettings()
        {
            //Copy current file as backup
            var currentFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\PinupPlayer\\";
            var fileInfo = new FileInfo(_iniFilePath);
            Directory.CreateDirectory(currentFolder);
            string filePath = $"{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}";
            File.Copy(_iniFilePath, currentFolder + filePath);

            Log.Information("{ToolName}: Wrote setting backup: {location}", ToolName, filePath);

            //Save the file
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    _parser.WriteData(sw, _data);
                }
                var text = Encoding.UTF8.GetString(ms.ToArray());
                //Post fixup (Removed = spaces)
                text = text.Replace(" = ", "=").RemoveBlankLines("\r\n");
                Encoding enc = new UTF8Encoding(false);
                File.WriteAllText(_iniFilePath, text, enc);
            }
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
            //All sections use virtual offsets for X/Y positions 
            _data[section][x] = regionRectangle.RegionOffsetX.ToString();
            _data[section][y] = regionRectangle.RegionOffsetY.ToString();
        }

        public void SetDisplayDetails(string displayName, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == displayName.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.ToLower().Contains(displayName.ToLower()));

            if (regionRectangle != null)
            {
                var virtualRegionRectangle = new RegionRectangle(regionRectangle.RegionDisplayHeight, regionRectangle.RegionDisplayWidth,
                    display.VirtualResolutionOffsetX(regionRectangle), display.VirtualResolutionOffsetY(regionRectangle));
                SetRegionRectangle(GetSectionName(displayName), virtualRegionRectangle);
            }
        }

        public string GetSectionName(string displayName)
        {
            if (displayName == Consts.Playfield)
                return "INFO3";
            if (displayName == Consts.Backglass)
                return "INFO2";
            if (displayName == Consts.DMD)
                return "INFO1";
            if (displayName == Consts.Topper)
                return "INFO";
            if (displayName == Consts.Apron)
                return "INFO5";
            return null;
        }

        public ValidationResult Validate(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            //Validate Playfield
            var playFieldResult = ValidateRegion(Consts.Playfield, displayDetails);
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

        public ValidationResult ValidateRegion(string displayName, List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();
            RegionRectangle pinupPlayerCurrentRegion = GetRegionRectangle(GetSectionName(displayName));

            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == displayName.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(displayName));
            var monitorNumber = display?.GetMonitorNumber() - 1;

            if (regionRectangle != null)
            {
                if (pinupPlayerCurrentRegion.RegionDisplayHeight != regionRectangle.RegionDisplayHeight)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Height does not match. Expected: {regionRectangle.RegionDisplayHeight} Actual: {pinupPlayerCurrentRegion.RegionDisplayHeight}", MessageLevel.Error));
                }

                if (pinupPlayerCurrentRegion.RegionDisplayWidth != regionRectangle.RegionDisplayWidth)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Width does not match. Expected: {regionRectangle.RegionDisplayWidth} Actual: {pinupPlayerCurrentRegion.RegionDisplayWidth}", MessageLevel.Error));
                }

                var regionOffsetX = display.VirtualResolutionOffsetX(regionRectangle);
                if (pinupPlayerCurrentRegion.RegionOffsetX != regionOffsetX)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display X Offset does not match. Expected: {regionOffsetX} Actual: {pinupPlayerCurrentRegion.RegionOffsetX}", MessageLevel.Error));
                }

                var regionOffsetY = display.VirtualResolutionOffsetY(regionRectangle);
                if (pinupPlayerCurrentRegion.RegionOffsetY != regionOffsetY)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Y Offset does not match. Expected: {regionOffsetY} Actual: {pinupPlayerCurrentRegion.RegionOffsetY}", MessageLevel.Error));
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
