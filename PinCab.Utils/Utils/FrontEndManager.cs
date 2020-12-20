using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils.PinballX;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    public class FrontEndManager
    {
        private readonly ProgramSettings _settings = new ProgramSettings();
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();
        private readonly PinballXManager _pinballXManager = null;
        private readonly List<PinballXSystem> _systems = null;

        public FrontEndManager()
        {
            _settings = _settingManager.LoadSettings();

            if (_settings.PinballXExists())
                _pinballXManager = new PinballXManager(_settings.PinballXIniPath);

            _systems = _pinballXManager.ParseSystems();
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
