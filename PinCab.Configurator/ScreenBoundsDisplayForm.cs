using PinCab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
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
            //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            var pen = new Pen(Color.Red, 20);
            //0,0 because it's in the context of the form that is already moved to the proper screen
            var rectangle = new Rectangle(0, 0, _displayDetail.Display.GetScreen().Bounds.Width, _displayDetail.Display.GetScreen().Bounds.Height);
            e.Graphics.DrawRectangle(pen, rectangle);

            if (!string.IsNullOrEmpty(_displayDetail.DisplayLabel))
            {
                //GraphicsPath path = new GraphicsPath();
                
                Font drawFont = new Font("Arial", 40, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.Red);

                //path.AddString(_displayDetail.DisplayLabel, FontFamily.GenericSansSerif, (int)FontStyle.Regular, e.Graphics.DpiY * 40 / 72, new Point(10,10), new StringFormat());
                //e.Graphics.DrawPath(new Pen(Color.Red, 4.9f), path);
                e.Graphics.DrawString(_displayDetail.DisplayLabel, drawFont, drawBrush, 20, 20); //20 is the rectangle line width, so move it inside of that
            }

            //Draw the visible screen area for this screen (meaning it isn't going to display full screen, instead it will be bound by a box)
            //This is typically for LCD DMD folks, who are using a large screen, but only showing a portion of the screen in the backbox
            foreach (var region in _displayDetail.RegionRectangles)
            {
                if (region.RegionOffsetX != 0 || region.RegionOffsetY != 0 || region.RegionDisplayHeight != 0 || region.RegionDisplayWidth != 0)
                {
                    var pen2 = new Pen(region.RegionColor, 10);
                    var rectangle2 = new Rectangle(region.RegionOffsetX, region.RegionOffsetY, region.RegionDisplayWidth, region.RegionDisplayHeight);
                    e.Graphics.DrawRectangle(pen2, rectangle2);

                    //Display the region label inside the lower left corner of the region
                    if (!string.IsNullOrEmpty(region.RegionLabel))
                    {
                        Font drawFont = new Font("Arial", 20, FontStyle.Bold);
                        SolidBrush drawBrush = new SolidBrush(region.RegionColor);
                        int lowerLeftCornerY = (region.RegionOffsetY + region.RegionDisplayHeight) - 40;
                        if (lowerLeftCornerY < 0)
                            lowerLeftCornerY = 0;
                        e.Graphics.DrawString(region.RegionLabel, drawFont, drawBrush, region.RegionOffsetX + 10, lowerLeftCornerY);
                    }
                }
            }
        }


    }
}
