using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinballY
{
    public class SettingKeyValue<T>
    {
        public SettingKeyValue() { }
        public SettingKeyValue(string key, T value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public T Value { get; set; }
    }
}
