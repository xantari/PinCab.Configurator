using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class ToolValidationResult : ValidationResult
    {
        public ToolValidationResult() : base()
        {
            OutputValidationMessages = true;
            MessageType = ValidationMessageType.ValidationMessage;
        }

        public ToolValidationResult(ValidationResult result) : base()
        {
            this.IsValid = result.IsValid;
            this.Messages = result.Messages;
            OutputValidationMessages = true;
            MessageType = ValidationMessageType.ValidationMessage;
        }

        public string ToolName { get; set; }
        public string FunctionExecuted { get; set; }
        public bool OutputValidationMessages { get; set; }
        public ValidationMessageType MessageType {get;set;}
    }

    public enum ValidationMessageType
    {
        ToolMessage,
        ValidationMessage
    }
}
