using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Extensions
{
    public static class RegistryKeyExtensions
    {
        public static void SetKeyBoolAsInt(this RegistryKey key, string keyName, bool value)
        {
            key.SetValue(keyName, value ? 1 : 0);
        }

        public static void SetOrDeleteKeyBoolAsInt(this RegistryKey key, string keyName, bool? value)
        {
            if (!value.HasValue) //Delete the key if it doesn't have a value
            {
                if (key.GetValue(keyName) != null)
                    key.DeleteValue(keyName);
            }
            else
            {
                key.SetValue(keyName, value.Value ? 1 : 0);
            }
        }

        public static void SetOrDeleteKeyInt(this RegistryKey key, string keyName, int? value)
        {
            if (!value.HasValue) //Delete the key if it doesn't have a value
            {
                if (key.GetValue(keyName) != null)
                    key.DeleteValue(keyName);
            }
            else
            {
                key.SetValue(keyName, value.Value);
            }
        }

        public static void SetOrDeleteKeyUInt(this RegistryKey key, string keyName, uint? value)
        {
            if (!value.HasValue) //Delete the key if it doesn't have a value
            {
                if (key.GetValue(keyName) != null)
                    key.DeleteValue(keyName);
            }
            else
            {
                key.SetValue(keyName, value.Value);
            }
        }
    }
}
