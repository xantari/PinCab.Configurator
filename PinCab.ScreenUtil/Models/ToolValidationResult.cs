using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models
{
    public class ToolValidationResult : ValidationResult
    {
        public ToolValidationResult() : base()
        {
        }

        public ToolValidationResult(ValidationResult result) : base()
        {
            this.IsValid = result.IsValid;
            this.Messages = result.Messages;
        }

        public string ToolName { get; set; }
        public string FunctionExecuted { get; set; }
       
    }
}
