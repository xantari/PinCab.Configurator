using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.ScreenUtil.Extensions
{
    public static class WinformsExtensions
    {
        public static void BindEnumToCombobox<T>(this ComboBox comboBox, T defaultSelection)
        {
            var list = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value.ToString())
                .ToList();

            comboBox.DataSource = list;
            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "value";

            foreach (var opts in list)
            {
                if (opts.value.ToString() == defaultSelection.ToString())
                {
                    comboBox.SelectedItem = opts;
                }
            }
        }

        public static T GetValueOrDefault<T>(this DataRow row, string columnName)
        {
            object columnValue = row[columnName];

            if (!(columnValue is DBNull))
                return (T)columnValue;

            return default(T);
        }
    }
}
