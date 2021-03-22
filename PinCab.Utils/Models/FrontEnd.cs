using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public override string ToString()
        {
            return Name;
        }
    }
}
