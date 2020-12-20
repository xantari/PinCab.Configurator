using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Messages = new List<ValidationMessage>();
        }

        public bool IsValid { get; set; } = true;
        public List<ValidationMessage> Messages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeLevel">Include error level</param>
        /// <param name="carriageReturn">Carriage return (default is \r\n), could also be <br> for HTML</param>
        /// <returns></returns>
        public string GetMessagesAsText(bool includeLevel = false, string carriageReturn = "\r\n")
        {
            StringBuilder sb = new StringBuilder();
            foreach (var message in Messages)
            {
                if (includeLevel)
                    sb.Append($"{message.Level.ToString()}: {message.Message}");
                else
                    sb.Append(message.Message);
            }
            return sb.ToString();
        }
    }
}
