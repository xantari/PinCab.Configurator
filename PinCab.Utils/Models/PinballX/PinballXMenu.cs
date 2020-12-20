using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PinCab.Utils.Models.PinballX
{
	[XmlRoot("menu")]
	public class PinballXMenu
	{
		[XmlElement("game")]
		public List<PinballXGame> Games = new List<PinballXGame>();
	}
}
