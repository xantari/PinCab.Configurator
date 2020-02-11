using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil
{
    public static class StringExtensions
    {
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
            string[] lines = text.Split('\n');
            int i;
            StringBuilder sb = new StringBuilder();
            for (i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    sb.Append(lines[i]);
                }
            }
            return sb.ToString();
        }
    }
}
