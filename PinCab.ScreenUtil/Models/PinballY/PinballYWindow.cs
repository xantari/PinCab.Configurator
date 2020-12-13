using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models.PinballY
{
    public class PinballYWindow
    {
        /// <summary>
        /// PlayfieldWindow, BackglassWindow, DMDWindow, TopperWindow, InstaCardWindow
        /// </summary>
        public string WindowName { get; set; }
        public string Position { get; set; }
        public int Rotation { get; set; }
        public bool MirrorHorz { get; set; }
        public bool MirrorVert { get; set; }
        public bool FullScreen { get; set; }
        public bool Maximized { get; set; }
        public bool Minimized { get; set; }
        public string FullScreenPosition { get; set; }

        public PinballYWindowRectangle GetFullscreenRectangle()
        {
            if (!string.IsNullOrEmpty(FullScreenPosition))
            {
                var rect = new PinballYWindowRectangle();
                var data = FullScreenPosition.Split(','); //X,Y,width,height
                rect.Left = Convert.ToInt32(data[0]);
                rect.Top = Convert.ToInt32(data[1]);
                rect.Right = Convert.ToInt32(data[2]);
                rect.Bottom = Convert.ToInt32(data[3]);
                return rect;
            }
            return null; 
        }

        public void SetFullscreenRectangle(PinballYWindowRectangle rect)
        {
            FullScreenPosition = $"{rect.Left},{rect.Top},{rect.Right},{rect.Bottom}";
        }

        public PinballYWindowRectangle GetWindowPositionRectangle()
        {
            if (!string.IsNullOrEmpty(Position))
            {
                var rect = new PinballYWindowRectangle();
                var data = Position.Split(','); //X,Y,width,height
                rect.Left = Convert.ToInt32(data[0]);
                rect.Top = Convert.ToInt32(data[1]);
                rect.Right = Convert.ToInt32(data[2]);
                rect.Bottom = Convert.ToInt32(data[3]);
                return rect;
            }
            return null;
        }
        public void SetPositionRectangle(PinballYWindowRectangle rect)
        {
            Position = $"{rect.Left},{rect.Top},{rect.Right},{rect.Bottom}";
        }
    }
}
