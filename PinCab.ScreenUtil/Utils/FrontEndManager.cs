using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Models.PinballX;
using PinCab.ScreenUtil.Utils.PinballX;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils
{
    public class FrontEndManager
    {
        private readonly ProgramSettings _settings = new ProgramSettings();
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();
        private readonly PinballXManager _pinballXManager = null;

        public FrontEndManager()
        {
            _settings = _settingManager.LoadSettings();

            if (_settings.PinballXExists())
                _pinballXManager = new PinballXManager(_settings.PinballXIniPath);

            var systems = _pinballXManager.ParseSystems();
        }

        public List<FrontEnd> GetListOfActiveFrontEnds()
        {
            var list = new List<FrontEnd>();
            if (_settings.PinupPopperExists())
                list.Add(new FrontEnd() { Name = "Pinup Popper", SettingFilePath = _settings.PinupPopperSqlLiteDbPath, System = FrontEndSystem.PinupPopper });
            if (_settings.PinballXExists())
                list.Add(new FrontEnd() { Name = "Pinball X", SettingFilePath = _settings.PinballXIniPath, System = FrontEndSystem.PinballX });
            if (_settings.PinballYExists())
                list.Add(new FrontEnd() { Name = "Pinball Y", SettingFilePath = _settings.PinballYSettingsPath, System = FrontEndSystem.PinballY });
            return list;
        }
    }
}
