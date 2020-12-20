using IniParser;
using IniParser.Model;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils.DmdExt;
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
    /// P-ROC Utility
    /// </summary>
    public class ProcUtil
    {
        public const string ToolName = "P-ROC";

        public ProcUtil()
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
            ($"{ToolName}: You will need to manually edit your user_settings.yaml. For example, go to C:\\P-ROC\\Games\\cactuscanyon\\config\\user_settings.yaml and put in the following X/Y Offsets on this line: \r\n", MessageLevel.Information));
            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: Color Display Pixel Size: 8, Color Display X Offset: {regionOffsetX}, Color Display Y Offset: {regionOffsetY}\r\n", MessageLevel.Information));
            //result.Messages.Add(new ValidationMessage
            //($"{ToolName}: Dot Matrix Horizontal Position: {regionOffsetX}", MessageLevel.Information));
            //result.Messages.Add(new ValidationMessage
            //($"{ToolName}: Dot Matrix Veritical Position: {regionOffsetY}", MessageLevel.Information));
            result.Messages.Add(new ValidationMessage
            ($"{ToolName}: NOTE: You can change Color Display Pixel Size: if you want to increase/decrease the size of the DMD.", MessageLevel.Information));

            return result;
        }

      
    }
}
