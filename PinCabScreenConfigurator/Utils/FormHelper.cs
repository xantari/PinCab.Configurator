using PinCab.ScreenUtil;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator.Utils
{
    public class FormHelper
    {
        private ProgramSettings _settings;
        private List<DisplayDetail> _displayDetails;
        private TextBox _txtData;

        public FormHelper(ProgramSettings settings, List<DisplayDetail> displayDetails, TextBox txtData)
        {
            _settings = settings;
            _displayDetails = displayDetails;
            _txtData = txtData;
        }

        public void ValidatePinballX()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _pinballXUtil = new PinballXUtil(_settings.PinballXIniPath);

                var result = _pinballXUtil.Validate(_displayDetails);
                LogValidationResult("PinballX", result);
            }
            else
                _txtData.Text += "PinballX Ini Path not set yet.";
        }

        public void WritePinballXSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _pinballXUtil = new PinballXUtil(_settings.PinballXIniPath);

                _pinballXUtil.SetDisplayDetails(Consts.DMD, _displayDetails);
                _pinballXUtil.SetDisplayDetails(Consts.Topper, _displayDetails);
                _pinballXUtil.SetDisplayDetails(Consts.Apron, _displayDetails);
                _pinballXUtil.SetDisplayDetails(Consts.Backglass, _displayDetails);

                var display = _displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains(Consts.Playfield));
                if (display != null)
                    _pinballXUtil.SetMonitorNumber(PinballXUtil.Display, display.GetMonitorNumber() - 1);

                _pinballXUtil.SaveSettings();
                _txtData.Text += $"PinballX Write command completed.\r\n";
                Log.Information("PinballX Write command completed.");
            }
            else
                _txtData.Text += "PinballX Ini Path not set yet.";
        }

        public void ValidateFutureDmd()
        {
            if (!string.IsNullOrEmpty(_settings.FutureDMDIniPath))
            {
                var _util = new FutureDmdUtil(_settings.FutureDMDIniPath);

                var result = _util.Validate(_displayDetails);
                LogValidationResult("FutureDMD", result);
            }
            else
                _txtData.Text += "FutureDMD Ini Path not set yet.";
        }

        public void WriteFutureDMDSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _util = new FutureDmdUtil(_settings.PinballXIniPath);

                _util.SetDisplayDetails(Consts.DMD, _displayDetails);

                _util.SaveSettings();
                _txtData.Text += $"FutureDMD Write command completed.\r\n";
                Log.Information("FutureDMD Write command completed.");
            }
            else
                _txtData.Text += "FutureDMD Ini Path not set yet.";
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
