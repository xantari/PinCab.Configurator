using Pincab.ScreenUtil;
using Pincab.ScreenUtil.Models;
using Pincab.ScreenUtil.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCabScreenConfigurator.Utils
{
    public class ValidationHelper
    {
        private ProgramSettings _settings;
        private List<DisplayDetail> _displayDetails;
        private TextBox _txtData;

        public ValidationHelper(ProgramSettings settings, List<DisplayDetail> displayDetails, TextBox txtData) {
            _settings = settings;
            _displayDetails = displayDetails;
            _txtData = txtData;
        }

        public void ValidatePinballX()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _pinballXUtil = new PinballXUtil(_settings.PinballXIniPath);
                var dmdDisplay = _displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains("DMD"));
                var regionDmdRectangle = dmdDisplay?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains("DMD"));
                if (regionDmdRectangle == null)
                {
                    _txtData.Text += "Unable to locate DMD monitor. Have you specified it yet?\r\n";
                }
                else
                {
                    var result = _pinballXUtil.Validate(regionDmdRectangle, dmdDisplay.GetMonitorNumber());
                    LogValidationResult("PinballX", result);
                }
            }
        }

        public void WritePinballXSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _pinballXUtil = new PinballXUtil(_settings.PinballXIniPath);
                var dmdDisplay = _displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains("DMD"));
                var regionDmdRectangle = dmdDisplay?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains("DMD"));
                if (regionDmdRectangle == null)
                {
                    _txtData.Text += "Unable to locate DMD monitor. Have you specified it yet?\r\n";
                }
                else
                {
                    _pinballXUtil.SetDmdRegionRectangle(regionDmdRectangle);
                    _pinballXUtil.SetMonitorNumber(dmdDisplay.GetMonitorNumber());
                    _pinballXUtil.SaveSettings();
                }
            }
        }

        private void LogValidationResult(string command, ValidationResult result)
        {
            if (result?.Messages.Count() > 0)
            {
                _txtData.Text += $"{command} validation error: \r\n";
                foreach (var message in result.Messages)
                {
                    Log.Error("Validation Error: {msg}", message.Message);
                    _txtData.Text += message.Message + "\r\n";
                }
            }
            else
                _txtData.Text += $"{command} validated. No issues found.\r\n";
        }
    }
}
