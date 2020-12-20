using PinCab.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Extensions
{
    public static class ValidationExtensions
    {
        public static bool HasAnyErrors(this List<ValidationMessage> messages)
        {
            return messages.Any(c => c.Level == MessageLevel.Error);
        }
    }
}
