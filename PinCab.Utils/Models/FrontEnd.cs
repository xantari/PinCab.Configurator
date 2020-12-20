using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class FrontEnd
    {
        public FrontEnd() { }
        public string Name { get;set;}
        public string SettingFilePath { get; set; }
        public FrontEndSystem System { get; set; }
    }

    public enum FrontEndSystem
    {
        PinballX,
        PinballY,
        PinupPopper
    }
}
