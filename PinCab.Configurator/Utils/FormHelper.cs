using PinCab.ScreenUtil;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private BackgroundWorker _backgroundWorkerProgressBar;

        public FormHelper(ProgramSettings settings, List<DisplayDetail> displayDetails, TextBox txtData, BackgroundWorker backgroundWorkerProgressBar)
        {
            _settings = settings;
            _displayDetails = displayDetails;
            _txtData = txtData;
            _backgroundWorkerProgressBar = backgroundWorkerProgressBar;
            _backgroundWorkerProgressBar.DoWork += _backgroundWorkerProgressBar_DoWork;
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

        public void ValidateDmdDeviceIniSettings()
        {
            if (!string.IsNullOrEmpty(_settings.DMDDeviceIniPath))
            {
                if (!File.Exists(_settings.DMDDeviceIniPath))
                {
                    _txtData.Text += $"{DmdDeviceUtil.ToolName}: DMDDevice.ini path file not found: " + _settings.DMDDeviceIniPath;
                    return;
                }
                var util = new DmdDeviceUtil(_settings.DMDDeviceIniPath);
                var result = util.Validate(_displayDetails);
                LogValidationResult(DmdDeviceUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{DmdDeviceUtil.ToolName}: DMDDevice.ini path not set. Check settings.";
        }

        public void WriteDmdDeviceIniSettings()
        {
            if (!string.IsNullOrEmpty(_settings.DMDDeviceIniPath))
            {
                if (!File.Exists(_settings.DMDDeviceIniPath))
                {
                    _txtData.Text += $"{DmdDeviceUtil.ToolName}: DMDDevice.ini path file not found: " + _settings.DMDDeviceIniPath;
                    return;
                }
                var util = new DmdDeviceUtil(_settings.DMDDeviceIniPath);
                util.SaveSettings(_displayDetails);
                _txtData.Text += $"{DmdDeviceUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{DmdDeviceUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{DmdDeviceUtil.ToolName}: DMDDevice.ini path not set. Check settings.";
        }

        public void ValidateVpinMameDefaultKey()
        {
            var util = new VpinMameUtil();
            if (util.KeyExists())
            {
                var result = util.ValidatePinMameDefaultKeyPosition(_displayDetails);
                LogValidationResult(VpinMameUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{VpinMameUtil.ToolName}: Unable to find VPinMame registry key. Have you installed it and registered it yet?";
        }

        public void WriteVpinMameDefaultKey()
        {
            var util = new VpinMameUtil();
            if (util.KeyExists())
            {
                var result = util.SetPinMameDefault(_displayDetails);
                if (!result.IsValid)
                    LogValidationResult(VpinMameUtil.ToolName, result);
                _txtData.Text += $"{VpinMameUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{VpinMameUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{VpinMameUtil.ToolName}: Unable to find VPinMame registry key. Have you installed it and registered it yet?";
        }

        public void ValidateVpinMameRomKeys()
        {
            var util = new VpinMameUtil();
            if (util.KeyExists())
            {
                if (!_backgroundWorkerProgressBar.IsBusy)
                    _backgroundWorkerProgressBar.RunWorkerAsync(BackgroundProgressAction.PinMameValidateAllPreviousRunRoms);
            }
            else
                _txtData.Text += $"{VpinMameUtil.ToolName}: Unable to find VPinMame registry key. Have you installed it and registered it yet?";
        }

        private void _backgroundWorkerProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (BackgroundProgressAction)Enum.Parse(typeof(BackgroundProgressAction), e.Argument.ToString());
            if (arg == BackgroundProgressAction.PinMameValidateAllPreviousRunRoms)
            {
                var util = new VpinMameUtil();
                var result = util.ValidatePinMamePositionAllROMs(_displayDetails, true, _backgroundWorkerProgressBar.ReportProgress);
                var toolResult = new ToolValidationResult(result);
                toolResult.ToolName = VpinMameUtil.ToolName;
                toolResult.FunctionExecuted = arg.ToString();
                e.Result = toolResult;
            }
            else if (arg == BackgroundProgressAction.PinMameWriteAllPreviousRunRoms)
            {
                var util = new VpinMameUtil();
                var result = util.SetPinMamePositionAllROMs(_displayDetails, true, _backgroundWorkerProgressBar.ReportProgress);
                var toolResult = new ToolValidationResult(result);
                toolResult.ToolName = VpinMameUtil.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.ToString();
                e.Result = toolResult;
            }
        }

        public void WriteVpinMameRomKeys()
        {
            var util = new VpinMameUtil();
            if (util.KeyExists())
            {
                if (!_backgroundWorkerProgressBar.IsBusy)
                    _backgroundWorkerProgressBar.RunWorkerAsync(BackgroundProgressAction.PinMameWriteAllPreviousRunRoms);
            }
            else
                _txtData.Text += $"{VpinMameUtil.ToolName}: Unable to find VPinMame registry key. Have you installed it and registered it yet?";
        }

        public void ValidatePinupPlayerSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinupPlayerPath))
            {
                if (!File.Exists(_settings.PinupPlayerPath))
                {
                    _txtData.Text += $"{PinupPlayerUtil.ToolName}: PinUpPlayer.ini path file not found: " + _settings.PinballYSettingsPath;
                    return;
                }
                var util = new PinupPlayerUtil(_settings.PinupPlayerPath);
                var result = util.Validate(_displayDetails);
                LogValidationResult(PinupPlayerUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{PinupPlayerUtil.ToolName}: PinUpPlayer.ini path not set. Check settings.";
        }

        public void WritePinupPlayerSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinupPlayerPath))
            {
                if (!File.Exists(_settings.PinupPlayerPath))
                {
                    _txtData.Text += $"{PinupPlayerUtil.ToolName}: PinUpPlayer.ini path file not found: " + _settings.PinupPlayerPath;
                    return;
                }
                var util = new PinupPlayerUtil(_settings.PinupPlayerPath);

                util.SetDisplayDetails(Consts.DMD, _displayDetails);
                util.SetDisplayDetails(Consts.Playfield, _displayDetails);
                util.SetDisplayDetails(Consts.Backglass, _displayDetails);
                util.SetDisplayDetails(Consts.Topper, _displayDetails);
                util.SetDisplayDetails(Consts.Apron, _displayDetails);

                util.SaveSettings();
                _txtData.Text += $"{PinupPlayerUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{PinupPlayerUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{PinupPlayerUtil.ToolName}: PinUpPlayer.ini path not set. Check settings.";
        }

        public void ValidatePinballYSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinballYSettingsPath))
            {
                if (!File.Exists(_settings.PinballYSettingsPath))
                {
                    _txtData.Text += $"{PinballYUtil.ToolName}: Settings.txt path file not found: " + _settings.PinballYSettingsPath;
                    return;
                }
                var util = new PinballYUtil(_settings.PinballYSettingsPath);
                var result = util.Validate(_displayDetails);
                LogValidationResult(PinballYUtil.ToolName, result);
            }
            else
                _txtData.Text += $"{PinballYUtil.ToolName}: Settings.txt path not set. Check settings.";
        }

        public void WritePinballYSettings()
        {
            if (!string.IsNullOrEmpty(_settings.PinballYSettingsPath))
            {
                if (!File.Exists(_settings.PinballYSettingsPath))
                {
                    _txtData.Text += $"{PinballYUtil.ToolName}: Settings.txt path file not found: " + _settings.PinballYSettingsPath;
                    return;
                }
                var util = new PinballYUtil(_settings.PinballYSettingsPath);

                util.SetDisplayDetails(Consts.DMD, _displayDetails);
                util.SetDisplayDetails(Consts.Playfield, _displayDetails);
                util.SetDisplayDetails(Consts.Backglass, _displayDetails);
                util.SetDisplayDetails(Consts.Topper, _displayDetails);
                util.SetDisplayDetails(Consts.Apron, _displayDetails);

                util.SaveSettings();
                _txtData.Text += $"{PinballYUtil.ToolName}: Write command completed.\r\n";
                Log.Information($"{PinballYUtil.ToolName}: Write command completed.");
            }
            else
                _txtData.Text += $"{PinballYUtil.ToolName}: Settings.txt path not set. Check settings.";
        }

        public void WritePinballFxSettings()
        {
            var util = new PinballFxUtil();
            var result = util.GetDisplayDetails(_displayDetails);
            LogToolValidationResult("GetDisplayDetails", result);
            _txtData.Text += $"{PinballFxUtil.ToolName}: Write command completed.\r\n";
            Log.Information($"{PinballFxUtil.ToolName}: Write command completed.");
        }

        public void LogValidationResult(string command, ValidationResult result)
        {
            var sb = new StringBuilder();
            if (result?.Messages.Count() > 0)
            {
                sb.Append($"{command} validation messages: \r\n");
                foreach (var message in result.Messages)
                {
                    if (message.Level == MessageLevel.Error)
                        Log.Error("{command}: Validation Error: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Warning)
                        Log.Warning("{command}: Validation Warning: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Information)
                        Log.Information("{command}: Validation Information: {message}", command, message.Message);
                    sb.Append(message.Message + "\r\n");
                }
            }

            if (result != null && result.IsValid)
            {
                var msg = $"{command}: Validated. No issues found.\r\n";
                Log.Information(msg);
                sb.Append(msg);
            }

            else
            {
                var msg = $"{command}: Validated. Issues found.\r\n";
                Log.Information(msg);
                sb.Append(msg);
            }

            _txtData.Text += sb.ToString();
        }

        public void LogToolValidationResult(string command, ValidationResult result)
        {
            var sb = new StringBuilder();
            if (result?.Messages.Count() > 0)
            {
                sb.Append($"{command} messages: \r\n");
                foreach (var message in result.Messages)
                {
                    if (message.Level == MessageLevel.Error)
                        Log.Error("{command}: Error: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Warning)
                        Log.Warning("{command}: Warning: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Information)
                        Log.Information("{command}: Information: {message}", command, message.Message);
                    sb.Append(message.Message + "\r\n");
                }
            }

            _txtData.Text += sb.ToString();
        }
    }
}
