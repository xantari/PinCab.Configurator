using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils.DmdExt
{
	public class VirtualDisplayPosition
	{
		public double Left { get; set; }
		public double Top { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		public VirtualDisplayPosition()
		{
		}

		public VirtualDisplayPosition(double left, double top, double width, double height)
		{
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}

		public override string ToString()
		{
			return $"{Width}x{Height}@{Left}/{Top}";
		}
	}
}
