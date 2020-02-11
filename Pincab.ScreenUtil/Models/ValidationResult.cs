using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pincab.ScreenUtil.Models
{
    public class ValidationResult
    {
        public ValidationResult() {
            Messages = new List<ValidationMessage>();
        }

        public bool IsValid { get; set; } = true;
        public List<ValidationMessage> Messages{ get; set; }
    }
}
