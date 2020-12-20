using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils;
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

namespace PinCab.Configurator
{
    public partial class GameManagerForm : Form
    {
        private readonly FrontEndManager manager = new FrontEndManager();
        public GameManagerForm()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            var frontEnds = manager.GetListOfActiveFrontEnds();
            if (frontEnds.Count == 0)
            {
                txtLog.Text = "No Front Ends detected. Have you pointed to the settings file for atleast one front end?";
                return;
            }
            else 
            {
                cmbFrontEnd.Items.AddRange(frontEnds.ToArray());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
