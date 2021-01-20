using PinCab.Utils;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
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
    public partial class AddEditGameForm : Form
    {
        private FrontEndGameViewModel _setting { get; set; }
        private FrontEndManager _manager { get; set; }
        public AddEditGameForm(FrontEndGameViewModel setting, FrontEndManager manager)
        {
            InitializeComponent();
            _setting = setting;
            _manager = manager;
            LoadForm();
        }

        private void LoadForm()
        {
            txtTableName.Text = _setting.FileName;
            txtDisplayName.Text = _setting.Description;
            txtManufacturer.Text = _setting.Manufacturer;
            txtYear.Text = _setting.Year;
            txtTheme.Text = _setting.Theme;
            txtAuthor.Text = _setting.Author;
            txtVersion.Text = _setting.Version;
            txtIpdb.Text = _setting.IPDBNumber;
            txtType.Text = _setting.Type;
            txtRom.Text = _setting.Rom;
            txtPlayers.Text = _setting.Players;
            txtPlayCount.Text = _setting.TimesPlayed.ToString();
            txtSeconds.Text = _setting.SecondsPlayed.ToString();
            txtAdded.Text = _setting.DateAdded.ToString();
            txtModified.Text = _setting.DateModified.ToString();
            txtAlternateExe.Text = _setting.AlternateExe;
            txtComment.Text = _setting.Comment;
            txtGameUrl.Text = _setting.TableFileUrl;
            chkHideBackglass.Checked = _setting.HideBackglass;
            chkHideDmd.Checked = _setting.HideDmd;
            chkHideTopper.Checked = _setting.HideTopper;
            chkEnabled.Checked = _setting.Enabled;
            chkFavorite.Checked = _setting.Favorite;
        }

        private FrontEndGameViewModel GetSettingFromControls()
        {
            _setting.FileName = txtTableName.Text.IfEmptyThenNull();
            _setting.Description = txtDisplayName.Text.IfEmptyThenNull();
            _setting.Manufacturer = txtManufacturer.Text.IfEmptyThenNull();
            _setting.Year = txtYear.Text.IfEmptyThenNull();
            _setting.Theme = txtTheme.Text.IfEmptyThenNull();
            _setting.Author = txtAuthor.Text.IfEmptyThenNull();
            _setting.Version = txtVersion.Text.IfEmptyThenNull();
            _setting.IPDBNumber = txtIpdb.Text.IfEmptyThenNull();
            _setting.Type = txtType.Text.IfEmptyThenNull();
            _setting.Rom = txtRom.Text.IfEmptyThenNull();
            _setting.Players = txtPlayCount.Text.IfEmptyThenNull();
            _setting.TimesPlayed = Convert.ToInt32(txtPlayCount.Text);
            _setting.SecondsPlayed = Convert.ToInt32(txtSeconds.Text);
            if (!string.IsNullOrEmpty(txtAdded.Text))
            {
                DateTime result;
                var success = DateTime.TryParse(txtAdded.Text, out result);
                if (success)
                    _setting.DateAdded = result;

            }
            if (!string.IsNullOrEmpty(txtModified.Text))
            {
                DateTime result;
                var success = DateTime.TryParse(txtModified.Text, out result);
                if (success)
                    _setting.DateModified = result;
            }
                
            _setting.AlternateExe = txtAlternateExe.Text.IfEmptyThenNull();
            _setting.Comment = txtComment.Text.IfEmptyThenNull();
            _setting.TableFileUrl = txtGameUrl.Text.IfEmptyThenNull();
            _setting.HideBackglass = chkHideBackglass.Checked;
            _setting.HideDmd = chkHideDmd.Checked;
            _setting.HideTopper = chkHideTopper.Checked;

            return _setting;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = GetSettingFromControls();
            _manager.SaveGame(result);
            Close();
        }

    }
}
