using PinCab.ScreenUtil.Extensions;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    public partial class PinMameRomSettingEditorForm : Form
    {
        private VpinMameRomSetting _setting { get; set; }
        private VPinMAMELib.Controller _controller { get; set; }
        private VpinMameUtil _util = new VpinMameUtil();
        public PinMameRomSettingEditorForm(VpinMameRomSetting setting, VPinMAMELib.Controller controller)
        {
            InitializeComponent();
            _setting = setting;
            _controller = controller;
            LoadForm();
        }

        private void LoadForm()
        {
            if (_setting.RomName == "default")
                lblRomName.Text = "default - Default setting for all first time run ROMs";
            else
                lblRomName.Text = $"{_setting.RomName} - {_controller.Games[_setting.RomName].Description}";
            chkEnableAntiAlias.SetThreeStateCheckbox(_setting.EnableAntiAlias);
            chkSkipStartup.SetThreeStateCheckbox(_setting.SkipStartup);
            numericAntiAliasPercentage.SetNumericUpDown(_setting.AntiAliasPercentage);
            numericOpacity.SetNumericUpDown(_setting.Opacity);
            chkBorder.SetThreeStateCheckbox(_setting.Border);
            chkTitle.SetThreeStateCheckbox(_setting.Title);
            chkScanLines.SetThreeStateCheckbox(_setting.Scanlines);
            chkDirectDraw.SetThreeStateCheckbox(_setting.DirectDraw);
            chkShowVpinMameDmd.SetThreeStateCheckbox(_setting.ShowVPinMameDmd);
            chkDirect3d.SetThreeStateCheckbox(_setting.Direct3D);
            chkAt91Jit.SetThreeStateCheckbox(_setting.At91jit);
            chkExternalDmdDevice.SetThreeStateCheckbox(_setting.ExternalDmdDevice);
            numericHeight.SetNumericUpDown(_setting.Height);
            numericWidth.SetNumericUpDown(_setting.Width);
            numericOffsetX.SetNumericUpDown(_setting.OffsetX);
            numericOffsetY.SetNumericUpDown(_setting.OffsetY);
            numericIntensityPerc0.SetNumericUpDown(_setting.IntensityPerc0);
            numericIntensityPerc33.SetNumericUpDown(_setting.IntensityPerc33);
            numericIntensityPerc66.SetNumericUpDown(_setting.IntensityPerc66);
            chkColorize.SetThreeStateCheckbox(_setting.Colorize);
            chkCabinetMode.SetThreeStateCheckbox(_setting.CabinetMode);
            chkIgnoreRomCrcCheck.SetThreeStateCheckbox(_setting.IgnoreRomCrc);
            chkRotateLeft.SetThreeStateCheckbox(_setting.RotateLeft);
            chkRotateRight.SetThreeStateCheckbox(_setting.RotateRight);
            chkFlipX.SetThreeStateCheckbox(_setting.FlipX);
            chkFlipY.SetThreeStateCheckbox(_setting.FlipY);
            numericSyncLevel.SetNumericUpDown(_setting.SyncLevel);
            chkResamplingQuality.SetThreeStateCheckbox(_setting.ResamplingQuality);
            chkDoubleDisplaySize.SetThreeStateCheckbox(_setting.DoubleDisplaySize);
            numericFastFrames.SetNumericUpDown(_setting.FastFrames);
            numericSampleRate.SetNumericUpDown(_setting.SampleRate);
            chkCompactMode.SetThreeStateCheckbox(_setting.CompactMode);
            if (_setting.SoundMode.HasValue)
            {
                if (_setting.SoundMode.Value == 0)
                    cmbSoundMode.SelectedIndex = 0;
                if (_setting.SoundMode.Value == 1) //Altsound
                    cmbSoundMode.SelectedIndex = 1;
                if (_setting.SoundMode.Value == 2) //PinSound
                    cmbSoundMode.SelectedIndex = 2;
            }
            else
                cmbSoundMode.SelectedIndex = 0; //VPinMame Default
            chkUseSamples.SetThreeStateCheckbox(_setting.UseSamples);
            chkEnableSound.SetThreeStateCheckbox(_setting.EnableSound);
            if (_setting.Red.HasValue && _setting.Green.HasValue && _setting.Blue.HasValue)
            {
                colorDialogDmdColor.Color = Color.FromArgb(_setting.Red.Value, _setting.Green.Value, _setting.Blue.Value);
            }
            else //Set default
                colorDialogDmdColor.Color = Color.FromArgb(255, 88, 32);
            btnDmdColor.BackColor = colorDialogDmdColor.Color;
        }

        private VpinMameRomSetting GetSettingFromControls()
        {
            var setting = new VpinMameRomSetting();
            setting.RomName = _setting.RomName;
            setting.EnableAntiAlias = chkEnableAntiAlias.GetThreeStateCheckboxBool();
            setting.SkipStartup = chkSkipStartup.GetThreeStateCheckboxBool();
            setting.AntiAliasPercentage = numericAntiAliasPercentage.GetNumericUpDown();
            setting.Opacity = numericOpacity.GetNumericUpDown();
            setting.Border = chkBorder.GetThreeStateCheckboxBool();
            setting.Title = chkTitle.GetThreeStateCheckboxBool();
            setting.Scanlines = chkScanLines.GetThreeStateCheckboxBool();
            setting.DirectDraw = chkDirectDraw.GetThreeStateCheckboxBool();
            setting.ShowVPinMameDmd = chkShowVpinMameDmd.GetThreeStateCheckboxBool();
            setting.Direct3D = chkDirect3d.GetThreeStateCheckboxBool();
            setting.At91jit = chkAt91Jit.GetThreeStateCheckboxBool();
            setting.ExternalDmdDevice = chkExternalDmdDevice.GetThreeStateCheckboxBool();
            setting.Height = numericHeight.GetNumericUpDown();
            setting.Width = numericWidth.GetNumericUpDown();
            setting.OffsetX = numericOffsetX.GetNumericUpDown();
            setting.OffsetY = numericOffsetY.GetNumericUpDown();
            setting.IntensityPerc0 = numericIntensityPerc0.GetNumericUpDown();
            setting.IntensityPerc33 = numericIntensityPerc33.GetNumericUpDown();
            setting.IntensityPerc66 = numericIntensityPerc66.GetNumericUpDown();
            setting.Colorize = chkColorize.GetThreeStateCheckboxBool();
            setting.CabinetMode = chkCabinetMode.GetThreeStateCheckboxBool();
            setting.IgnoreRomCrc = chkIgnoreRomCrcCheck.GetThreeStateCheckboxBool();
            setting.RotateLeft = chkRotateLeft.GetThreeStateCheckboxBool();
            setting.RotateRight = chkRotateRight.GetThreeStateCheckboxBool();
            setting.FlipX = chkFlipX.GetThreeStateCheckboxBool();
            setting.FlipY = chkFlipY.GetThreeStateCheckboxBool();
            setting.SyncLevel = numericSyncLevel.GetNumericUpDown();
            setting.ResamplingQuality = chkResamplingQuality.GetThreeStateCheckboxBool();
            setting.DoubleDisplaySize = chkDoubleDisplaySize.GetThreeStateCheckboxBool();
            setting.FastFrames = numericFastFrames.GetNumericUpDown();
            setting.SampleRate = numericSampleRate.GetNumericUpDown();
            setting.IntensityPerc33 = numericIntensityPerc33.GetNumericUpDown();
            setting.CompactMode = chkCompactMode.GetThreeStateCheckboxBool();
            setting.SoundMode = cmbSoundMode.SelectedIndex;
            setting.UseSamples = chkUseSamples.GetThreeStateCheckboxBool();
            setting.EnableSound = chkEnableSound.GetThreeStateCheckboxBool();
            setting.Red = colorDialogDmdColor.Color.R;
            setting.Green = colorDialogDmdColor.Color.G;
            setting.Blue = colorDialogDmdColor.Color.B;
            return setting;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = GetSettingFromControls();
            _util.SaveRomModelToRegsitry(result);
            Close();
        }

        private void btnDmdColor_Click(object sender, EventArgs e)
        {
            var result = colorDialogDmdColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnDmdColor.BackColor = colorDialogDmdColor.Color;
            }
        }
    }
}
