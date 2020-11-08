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

        public void ClearMessages()
        {
            _txtData.Text = string.Empty;
        }

        public void ValidatePinballX()
        {
            if (!string.IsNullOrEmpty(_settings.PinballXIniPath))
            {
                var _pinballXUtil = new PinballXUtil(_settings.PinballXIniPath);

                var result = _pinballXUtil.Validate(_displayDetails);
                LogValidationResult(PinballXUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{PinballXUtil.ToolName}: Ini Path not set yet.";
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

                var display = _displayDetails.FirstOrDefault(p => p.RegionRectangles.Any(c => c.RegionLabel == Consts.Playfield));
                if (display != null)
                    _pinballXUtil.SetMonitorNumber(PinballXUtil.Display, display.GetMonitorNumber() - 1);

                _pinballXUtil.SaveSettings();
                _txtData.Text += $"{PinballXUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{PinballXUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{PinballXUtil.ToolName}: Ini Path not set yet.";
        }

        public void ValidateFutureDmd()
        {
            if (!string.IsNullOrEmpty(_settings.FutureDMDIniPath))
            {
                var _util = new FutureDmdUtil(_settings.FutureDMDIniPath);

                var result = _util.Validate(_displayDetails);
                LogValidationResult(FutureDmdUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{FutureDmdUtil.ToolName}: Ini Path not set yet.";
        }

        public void WriteFutureDMDSettings()
        {
            if (!string.IsNullOrEmpty(_settings.FutureDMDIniPath))
            {
                var _util = new FutureDmdUtil(_settings.FutureDMDIniPath);

                _util.SetDisplayDetails(Consts.DMD, _displayDetails);

                _util.SaveSettings();
                _txtData.Text += $"{FutureDmdUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{FutureDmdUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{FutureDmdUtil.ToolName}: Ini Path not set yet.";
        }

        public void ValidateB2sSettings()
        {
            if (!string.IsNullOrEmpty(_settings.B2SScreenResPath))
            {
                var _util = new B2sUtil(_settings.B2SScreenResPath);

                var result = _util.Validate(_displayDetails);
                LogValidationResult(B2sUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{B2sUtil.ToolName}: Path not set yet.";
        }

        public void WriteB2sSettings()
        {
            if (!string.IsNullOrEmpty(_settings.B2SScreenResPath))
            {
                var util = new B2sUtil(_settings.B2SScreenResPath);

                util.SetDisplayDetails(Consts.DMD, _displayDetails);
                util.SetDisplayDetails(Consts.Playfield, _displayDetails);
                util.SetDisplayDetails(Consts.Backglass, _displayDetails);

                util.SaveSettings();
                _txtData.Text += $"{B2sUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{B2sUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{B2sUtil.ToolName}: Ini Path not set yet.";
        }

        public void ValidateUltraDmdSettings()
        {
            var util = new UltraDmdUtil();
            if (util.KeyExists())
            {
                var result = util.Validate(_displayDetails);
                LogValidationResult(UltraDmdUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{UltraDmdUtil.ToolName}: Registry key not found. Have you installed UltraDMD?";
        }

        public void WriteUltraDmdSettings()
        {
            var util = new UltraDmdUtil();
            if (util.KeyExists())
            {
                var result = util.SaveSettings(_displayDetails);
                if (result.IsValid)
                {
                    _txtData.Text += $"{UltraDmdUtil.ToolName}: Write command completed.\r\n";
                    Log.Information($"{UltraDmdUtil.ToolName}: Write command completed.");
                }
                else 
                {
                    _txtData.Text += result.GetMessagesAsText(true);
                }
            }
            else
                _txtData.Text += $"{UltraDmdUtil.ToolName}: Registry key not found. Have you installed UltraDMD?";
        }

        public void LogValidationResult(string command, ValidationResult result)
        {
            if (result?.Messages.Count() > 0)
            {
                _txtData.Text += $"{command} validation messages: \r\n";
                foreach (var message in result.Messages)
                {
                    if (message.Level == MessageLevel.Error)
                        Log.Error("{command}: Validation Error: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Warning)
                        Log.Warning("{command}: Validation Warning: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Information)
                        Log.Information("{command}: Validation Information: {message}", command, message.Message);
                    _txtData.Text += message.Message + "\r\n";
                }
            }

            if (result != null && result.IsValid)
                _txtData.Text += $"{command}: Validated. No issues found.\r\n";
            else
                _txtData.Text += $"{command}: Validated. Issues found.\r\n";
        }
    }
}
