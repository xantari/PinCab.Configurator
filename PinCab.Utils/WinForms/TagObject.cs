using PinCab.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Utils.WinForms
{
    public class TagObject : Label
    {
        public static int BtnRemoveWidth { get; set; } = 20;
        public static int BtnRemoveHeight { get; set; } = 20;
        // note: you can add get set methods and in the set method you can change value in runtime '
        public string DescriptionText { get; set; }
        //private SizeF size;
        //private int TagHeight { get; set; }
        //private int TagWidth { get; set; }
        private PictureBox btnRemove;

        // you can add any property you need backcolor forecolor etc...'

        private RemoveActionDelegate _removeAction;
        public delegate void RemoveActionDelegate();

        public TagObject(string descriptionText, RemoveActionDelegate removeAction = null)
        {
            DescriptionText = descriptionText;
            _removeAction = removeAction;
            //size = sizeVal;
            Font = new Font("Arial", 9, FontStyle.Bold);
        }

        public void Init()
        {
            Text = DescriptionText;
            Graphics g = this.CreateGraphics();
            SizeF size = g.MeasureString(Text, this.Font);
            Width = Convert.ToInt32(Math.Ceiling(size.Width)) + BtnRemoveWidth + 1;
            if (Width > 400) //Adjust the close icon to come back further (need to figure out what the correct formula for this is)
                Width = Width - 20;
            Height = Convert.ToInt32(Math.Ceiling(size.Height));
            TextAlign = ContentAlignment.TopLeft;
            Margin = new Padding(0);
            Padding = new Padding(0);
            //BorderStyle = BorderStyle.FixedSingle;
            //this.BackColor = Color.FromArgb(30, 30, 30);
            //this.ForeColor = Color.White;
            btnRemove = new PictureBox();
            btnRemove.Height = BtnRemoveHeight;
            btnRemove.Width = BtnRemoveWidth;
            btnRemove.Location = new Point(Width - btnRemove.Width - 1, Height / 2 - btnRemove.Height / 2);
            // original image url: https://www.google.co.il/search?q=close+icon+free&safe=off&rlz=1C1ASUM_enIL700IL700&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjVuJnbk5vZAhXKesAKHRXqDX8Q_AUICigB&biw=1440&bih=769#imgrc=2p_iHiqieStqCM:'
            btnRemove.Image = Resources.CloseIcon30px;
            btnRemove.SizeMode = PictureBoxSizeMode.StretchImage;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Click += btnRemove_Click;
            Controls.Add(btnRemove);
            g.Dispose();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // the user wants to delete this tag...'
            Dispose();
            _removeAction?.Invoke();
        }
    }
}
