using PinCab.Configurator.Utils;
using PinCab.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Configurator.Models
{
    public class PinmameBackgroundAction
    {
        public PinmameBackgroundAction()
        {
            CellsToCopy = new List<string>();
        }
        public BackgroundProgressAction Action { get; set; }
        public VpinMameRomSetting Setting { get; set; }
        public List<string> CellsToCopy { get; set; }
    }
}
