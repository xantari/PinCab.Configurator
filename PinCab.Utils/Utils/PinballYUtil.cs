using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballY;
using PinCab.Utils.Utils.PinballY;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    public class PinballYUtil
    {
        private PinballYConfiguration _config { get; set; }

        public const string ToolName = "PinballY";

        public PinballYUtil(string settingsTxtPath)
        {
            _config = new PinballYConfiguration(settingsTxtPath);
            _config.LoadSettings();
        }

        public void SaveSettings()
        {
            _config.SaveSettings();
        }

        public PinballYWindowRectangle GetRegionRectangle(WindowType windowType)
        {
            //PinballY stores the positions in X,Y,width,height
            //X is virtual offset
            //Width is also virtual, seems to take the layout of the screens and adds the screens in order
            //.FullScreenPosition is the value when it's full screen
            //otherwise its ".Position" setting. Use ".Position" if .FullScreen = 1
            var window = _config.GetWindow(windowType);
            if (window == null)
                return null;
            if (window.FullScreen)
                return window.GetFullscreenRectangle();
            else //Windowed
                return window.GetWindowPositionRectangle();
        }

        //public void SetRegionRectangle(string section, RegionRectangle regionRectangle)
        //{
        //    _data[section][height] = regionRectangle.RegionDisplayHeight.ToString();
        //    _data[section][width] = regionRectangle.RegionDisplayWidth.ToString();
        //    _data[section][x] = regionRectangle.RegionOffsetX.ToString();
        //    _data[section][y] = regionRectangle.RegionOffsetY.ToString();
        //}

        public void SetDisplayDetails(string displayName, List<DisplayDetail> displayDetails)
        {
            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == displayName.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.ToLower().Contains(displayName.ToLower()));

            var window = _config.GetWindow(GetWindowTypeByDisplayType(displayName).Value);

            if (window != null && regionRectangle != null)
            {
                var expectedRegionCoordinateVersion = display.GetVirtualCoordinateRectangle(regionRectangle);
                bool fullScreen = false;
                if (display.VirtualLeft() == expectedRegionCoordinateVersion.Left
                 && display.VirtualTop() == expectedRegionCoordinateVersion.Top
                 && display.VirtualRight() == expectedRegionCoordinateVersion.Right
                 && display.VirtualBottom() == expectedRegionCoordinateVersion.Bottom)
                    fullScreen = true;
                if (fullScreen)
                {
                    window.SetFullscreenRectangle(new PinballYWindowRectangle()
                    {
                        Left = expectedRegionCoordinateVersion.Left,
                        Top = expectedRegionCoordinateVersion.Top,
                        Right = expectedRegionCoordinateVersion.Right,
                        Bottom = expectedRegionCoordinateVersion.Bottom
                    });
                    window.FullScreen = true;
                    _config.SetWindow(window);
                }
                else 
                {
                    window.SetPositionRectangle(new PinballYWindowRectangle()
                    {
                        Left = expectedRegionCoordinateVersion.Left,
                        Top = expectedRegionCoordinateVersion.Top,
                        Right = expectedRegionCoordinateVersion.Right,
                        Bottom = expectedRegionCoordinateVersion.Bottom
                    });
                    window.FullScreen = false;
                    _config.SetWindow(window);
                }
            }
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

            //Validate Apron (InstaCardWindow in PinballY)
            var apronResult = ValidateRegion(Consts.Apron, displayDetails);
            if (apronResult.IsValid == false)
                result.IsValid = false;
            result.Messages.AddRange(apronResult.Messages);

            return result;
        }

        private WindowType? GetWindowTypeByDisplayType(string displayName)
        {
            if (displayName == Consts.Playfield)
                return WindowType.PlayfieldWindow;
            if (displayName == Consts.DMD)
                return WindowType.DMDWindow;
            if (displayName == Consts.Topper)
                return WindowType.TopperWindow;
            if (displayName == Consts.Backglass)
                return WindowType.BackglassWindow;
            if (displayName == Consts.Apron)
                return WindowType.InstaCardWindow;
            return null;
        }

        public ValidationResult ValidateRegion(string displayName, List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var pinballYCurrentRegion = GetRegionRectangle(GetWindowTypeByDisplayType(displayName).Value);

            var display = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == displayName.ToLower()));
            var regionRectangle = display?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(displayName));

            if (regionRectangle != null)
            {
                var regionCoordinateVersion = display.GetVirtualCoordinateRectangle(regionRectangle);

                if (pinballYCurrentRegion.Left != regionCoordinateVersion.Left)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Left does not match. Expected: {regionCoordinateVersion.Left} Actual: {pinballYCurrentRegion.Left}", MessageLevel.Error));
                }

                if (pinballYCurrentRegion.Top != regionCoordinateVersion.Top)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Display Top does not match. Expected: {regionCoordinateVersion.Top} Actual: {pinballYCurrentRegion.Top}", MessageLevel.Error));
                }

                //var regionOffsetX = display.VirtualResolutionOffsetX(regionRectangle);
                if (pinballYCurrentRegion.Right != regionCoordinateVersion.Right)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Right does not match. Expected: {regionCoordinateVersion.Right} Actual: {pinballYCurrentRegion.Right}", MessageLevel.Error));
                }

                //var regionOffsetY = display.VirtualResolutionOffsetY(regionRectangle);
                if (pinballYCurrentRegion.Bottom != regionCoordinateVersion.Bottom)
                {
                    result.Messages.Add(new ValidationMessage
                        ($"{ToolName}: {displayName} Region Bottom does not match. Expected: {regionCoordinateVersion.Bottom} Actual: {pinballYCurrentRegion.Bottom}", MessageLevel.Error));
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
