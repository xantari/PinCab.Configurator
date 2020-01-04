using Pincab.ScreenUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCabScreenConfigurator
{
    public partial class ScreenBoundsDisplayForm : Form
    {
        private DisplayDetail _displayDetail { get; set; }
        public ScreenBoundsDisplayForm(DisplayDetail displayDetail, Form ownerForm)
        {
            InitializeComponent();
            _displayDetail = displayDetail;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = displayDetail.Display.GetScreen().Bounds;
            //this.Location = new Point(displayDetail.Screen.Bounds.X, displayDetail.Screen.Bounds.Y);
            this.TopMost = false;
            this.Paint += F_Paint;
            this.TransparencyKey = this.BackColor;
            this.Owner = ownerForm;
            this.Show();
            this.Bounds = displayDetail.Display.GetScreen().Bounds;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private void F_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Red, 20);
            //0,0 because it's in the context of the form that is already moved to the proper screen
            var rectangle = new Rectangle(0, 0, _displayDetail.Display.GetScreen().Bounds.Width, _displayDetail.Display.GetScreen().Bounds.Height);
            e.Graphics.DrawRectangle(pen, rectangle);

            if (!string.IsNullOrEmpty(_displayDetail.DisplayLabel))
            {
                Font drawFont = new Font("Arial", 40, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                e.Graphics.DrawString(_displayDetail.DisplayLabel, drawFont, drawBrush, 20, 20); //20 is the rectangle line width, so move it inside of that
            }

            //Draw the visible screen area for this screen (meaning it isn't going to display full screen, instead it will be bound by a box)
            //This is typically for LCD DMD folks, who are using a large screen, but only showing a portion of the screen in the backbox
            if (_displayDetail.OffsetX != 0 || _displayDetail.OffsetY !=0 || _displayDetail.VisibleDisplayHeight != 0 || _displayDetail.VisibleDisplayWidth != 0)
            {
                var pen2 = new Pen(Color.Green, 10);
                var rectangle2 = new Rectangle(_displayDetail.OffsetX, _displayDetail.OffsetY, _displayDetail.VisibleDisplayWidth, _displayDetail.VisibleDisplayHeight);
                e.Graphics.DrawRectangle(pen2, rectangle2);
            }
        }


    }
}
