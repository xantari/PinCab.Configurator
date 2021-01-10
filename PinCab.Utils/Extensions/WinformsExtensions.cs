using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Utils.Extensions
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

        public static void SetThreeStateCheckbox(this CheckBox checkBox, bool? value)
        {
            if (value.HasValue)
                checkBox.Checked = value.Value;
            else
                checkBox.CheckState = CheckState.Indeterminate;
        }

        public static bool? GetThreeStateCheckboxBool(this CheckBox checkBox)
        {
            if (checkBox.CheckState == CheckState.Indeterminate)
                return null;
            return checkBox.Checked;
        }

        public static void SetNumericUpDown(this NumericUpDown numeric, int? value)
        {
            if (value.HasValue)
                numeric.Value = value.Value;
            else
                numeric.Value = -1;
        }
        public static void SetNumericUpDown(this NumericUpDown numeric, uint? value)
        {
            if (value.HasValue)
                numeric.Value = value.Value;
            else
                numeric.Value = -1;
        }
        public static int? GetNumericUpDown(this NumericUpDown numeric)
        {
            if (numeric.Value == -1)
                return null;
            return Convert.ToInt32(numeric.Value);
        }
        public static uint? GetNumericUpDownUInt(this NumericUpDown numeric)
        {
            if (numeric.Value == -1)
                return null;
            return Convert.ToUInt32(numeric.Value);
        }

        /// <summary>
        /// Provides very fast and basic column sizing for large data sets.
        /// </summary>
        //public static void FastAutoSizeColumns(this DataGridView targetGrid)
        //{
        //    // Cast out a DataTable from the target grid datasource.
        //    // We need to iterate through all the data in the grid and a DataTable supports enumeration.
        //    var gridTable = (BindingSource)targetGrid.DataSource;

        //    // Create a graphics object from the target grid. Used for measuring text size.
        //    using (var gfx = targetGrid.CreateGraphics())
        //    {
        //        // Iterate through the columns.
        //        for (int i = 0; i < targetGrid.Columns.Count; i++)
        //        {
        //            // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
        //            string[] colStringCollection = gridTablee.Where(r => r.Field<object>(i) != null).Select(r => r.Field<object>(i).ToString()).ToArray();

        //            // Sort the string array by string lengths.
        //            colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();

        //            // Get the last and longest string in the array.
        //            string longestColString = colStringCollection.Last();

        //            // Use the graphics object to measure the string size.
        //            var colWidth = gfx.MeasureString(longestColString, targetGrid.Font);

        //            // If the calculated width is larger than the column header width, set the new column width.
        //            if (colWidth.Width > targetGrid.Columns[i].HeaderCell.Size.Width)
        //            {
        //                targetGrid.Columns[i].Width = (int)colWidth.Width;
        //            }
        //            else // Otherwise, set the column width to the header width.
        //            {
        //                targetGrid.Columns[i].Width = targetGrid.Columns[i].HeaderCell.Size.Width;
        //            }
        //        }
        //    }
        //}

        public static int[] GetAutoSizeColumnsWidth(DataGridView grid)
        {
            var src = ((IEnumerable)grid.DataSource)
                .Cast<object>()
                .Select(x => x.GetType()
                    .GetProperties()
                    .Select(p => p.GetValue(x, null)?.ToString() ?? string.Empty)
                    .ToArray()
                );

            int[] widths = new int[grid.Columns.Count];
            if (src.Count() == 0)
                return widths;
            // Iterate through the columns.
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                string[] colStringCollection = src.Where(r => r[i] != null).Select(r => r[i].ToString()).ToArray();

                // Sort the string array by string lengths.
                colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();

                // Get the last and longest string in the array.
                string longestColString = colStringCollection.Last();

                // Use the graphics object to measure the string size.
                var colWidth = TextRenderer.MeasureText(longestColString, grid.Font);

                // If the calculated width is larger than the column header width, set the new column width.
                if (colWidth.Width > grid.Columns[i].HeaderCell.Size.Width)
                {
                    widths[i] = (int)colWidth.Width;
                }
                else // Otherwise, set the column width to the header width.
                {
                    widths[i] = grid.Columns[i].HeaderCell.Size.Width;
                }
            }

            return widths;
        }

        public static void SetAutoSizeColumnsWidth(DataGridView grid, int[] widths)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = widths[i];
            }
        }
    }
}
