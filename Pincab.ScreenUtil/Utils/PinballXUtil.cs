using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil.Utils
{
    public class PinballXUtil
    {
        private string _iniFilePath { get; set; }
        private IniData _data { get; set; }
        private FileIniDataParser _parser { get; set; }
        
        public PinballXUtil(string iniFilePath) {
            _iniFilePath = iniFilePath;
            _parser = new FileIniDataParser();
            _data = _parser.ReadFile(iniFilePath);
        }
    }

}
