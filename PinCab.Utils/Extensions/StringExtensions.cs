using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PinCab.Utils
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string value)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(value), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static string RemoveNonAsciiCharacters(this string s)
        {
            return Regex.Replace(s, @"[^\u0000-\u007F]+", string.Empty);
        }

        public static string RemoveInvalidFilenameChars(this string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Remove Blank Lines from text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delimiter">\n or \r\n</param>
        /// <returns></returns>
        public static string RemoveBlankLines(this string text, string delimiter)
        {
            string[] delim = new string[] { delimiter };
            string[] lines = text.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            int i;
            StringBuilder sb = new StringBuilder();
            for (i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    sb.Append(lines[i] + delimiter);
                }
            }
            return sb.ToString();
        }

        public static string IfEmptyThenNull(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;
            return text;
        }

        public static string FileSizeHumanReadable(this long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }
    }
}
