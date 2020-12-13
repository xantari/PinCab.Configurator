using IniParser;
using IniParser.Model;
using PinCab.ScreenUtil.Extensions;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils.DmdExt;
using Serilog;
using Serilog.Core;
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
    /// Pinball FX2 / FX3 Utility
    /// </summary>
    public class PinballFxUtil
    {
        public const string ToolName = "Pinball FX2/FX3";

        public PinballFxUtil()
        {
        }

        public ValidationResult GetDisplayDetails(List<DisplayDetail> displayDetails)
        {
            var result = new ValidationResult();

            var dmd = displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel.ToLower() == Consts.DMD.ToLower()));

            if (dmd == null)
                result.Messages.Add(new ValidationMessage($"{ToolName}: DMD not yet defined.", MessageLevel.Error));

            if (result.Messages.HasAnyErrors()) //Don't proceed forward with validations if they haven't defined the minimum necessary items
            {
                result.IsValid = false;
                return result;
            }

            var dmdRectangle = dmd?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains(Consts.DMD));

            var regionOffsetX = dmd.VirtualResolutionOffsetX(dmdRectangle);
            var regionOffsetY = dmd.VirtualResolutionOffsetY(dmdRectangle);

            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: Dot Matrix Horizontal Position: {regionOffsetX}", MessageLevel.Information));
            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: Dot Matrix Veritical Position: {regionOffsetY}", MessageLevel.Information));
            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: Dot Matrix Horizontal Size: {dmdRectangle.RegionDisplayWidth}", MessageLevel.Information));
            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: Dot Matrix Veritical Size: {dmdRectangle.RegionDisplayHeight}", MessageLevel.Information));

            return result;
        }

      
    }
}
