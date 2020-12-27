using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
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
        private VpinMameRomSetting _setting { get; set; }
        public AddEditGameForm(VpinMameRomSetting setting)
        {
            InitializeComponent();
            _setting = setting;
            LoadForm();
        }

        private void LoadForm()
        {
           
        }

        //private VpinMameRomSetting GetSettingFromControls()
        //{
           
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var result = GetSettingFromControls();
            //_util.SaveRomModelToRegsitry(result);
            Close();
        }

    }
}
