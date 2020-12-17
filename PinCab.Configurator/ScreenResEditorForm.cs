using PinCab.ScreenUtil;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDisplayAPI;

namespace PinCab.Configurator
{
    public partial class ScreenResEditorForm : Form
    {
        private ProgramSettings _settings;
        private B2sUtil _util;
        private List<DisplayDetail> _displayDetails { get; set; } = new List<DisplayDetail>();
        private readonly ProgramSettingsManager _settingsManager = new ProgramSettingsManager();

        public ScreenResEditorForm()
        {
            InitializeComponent();

            _settings = _settingsManager.LoadSettings();
            LoadDisplayDetails();

            if (!string.IsNullOrEmpty(_settings.B2SScreenResPath))
            {
                _util = new B2sUtil(_settings.B2SScreenResPath);
                DisplaySettings(_util.GetB2sIniModel());
            }
            else
            {
                var msg =  $"{B2sUtil.ToolName}: Path not set yet. (attempting to load screen res editor)";
                Log.Information(msg);
                MessageBox.Show(msg);
            }
        }

        private void DisplaySettings(B2sIni model)
        {
            LoadDisplayCombobox();

            txtPlayfieldWidth.Value = model.PlayfieldWidth;
            txtPlayfieldHeight.Value = model.PlayfieldHeight;
            txtBackglassWidth.Value = model.BackglassWidth;
            txtBackglassHeight.Value = model.BackglassHeight;

            foreach(DisplayDetail itm in cmbDisplay.Items)
            {
                if (itm.GetMonitorNumber() == model.BackglassDisplayNumber)
                    cmbDisplay.SelectedItem = itm;
            }

            txtBackglassXOffset.Value = model.BackglassXOffset;
            txtBackglassYOffset.Value = model.BackglassYOffset;
            txtDmdWidth.Value = model.DMDWidth;
            txtDmdHeight.Value = model.DMDHeight;
            txtDmdXOffset.Value = model.DMDXOffset;
            txtDmdYOffset.Value = model.DMDYOffset;
            chkYFlip.Checked = model.YFlip == 1 ? true : false;
        }

        private void LoadDisplayDetails()
        {
            _displayDetails.Clear();
            foreach (var display in Display.GetDisplays())
            {
                var screen = Screen.AllScreens.FirstOrDefault(p => p.DeviceName == display.DisplayName);
                var edidInfo = display.DevicePath.GetDisplayEdidData();
                _displayDetails.Add(new DisplayDetail() { Display = display, EdidInfo = edidInfo });
            }
        }

        private void LoadDisplayCombobox()
        {
            cmbDisplay.Items.Clear();
            foreach (var display in _displayDetails)
            {
                cmbDisplay.Items.Add(display);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new B2sIni()
            {
                PlayfieldWidth = Convert.ToInt32(txtPlayfieldWidth.Value),
                PlayfieldHeight = Convert.ToInt32(txtPlayfieldHeight.Value),
                BackglassWidth = Convert.ToInt32(txtBackglassWidth.Value),
                BackglassHeight = Convert.ToInt32(txtBackglassHeight.Value),
                BackglassDisplayNumber = (cmbDisplay.SelectedItem as DisplayDetail).GetMonitorNumber(),
                BackglassXOffset = Convert.ToInt32(txtBackglassXOffset.Value),
                BackglassYOffset = Convert.ToInt32(txtBackglassYOffset.Value),
                DMDWidth = Convert.ToInt32(txtDmdWidth.Value),
                DMDHeight = Convert.ToInt32(txtDmdHeight.Value),
                DMDXOffset = Convert.ToInt32(txtDmdXOffset.Value),
                DMDYOffset = Convert.ToInt32(txtDmdYOffset.Value),
                YFlip = chkYFlip.Checked ? 1 : 0
            };
            _util.SaveB2sIniModel(model);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
