using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models.PinballY
{
    public class PinballYSetting
    {
        public PinballYSetting() { }
        public PinballYSetting(SettingEnum type, string data) 
        {
            Type = type;
            Data = data;
        }
        public SettingEnum Type { get; set; }
        public string Data { get; set; }

        public SettingKeyValue<string> ParseSetting()
        {
            if (Type == SettingEnum.Setting && Data.Contains("="))
            {
                var data = Data.Split('=');
                return new SettingKeyValue<string>(data[0].Trim(), data[1].Trim());
            }
            return null;
        }

        public void SetSetting(SettingKeyValue<string> setting)
        {
            if (Type == SettingEnum.Setting)
            {
                Data = $"{setting.Key} = {setting.Value}{Environment.NewLine}";
            }
        }
    }
}
