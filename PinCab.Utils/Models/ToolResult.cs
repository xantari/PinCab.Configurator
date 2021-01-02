using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class ToolResult : ValidationResult
    {
        public ToolResult() : base()
        {
            OutputMessages = true;
            MessageType = ValidationMessageType.ValidationMessage;
        }

        public ToolResult(string toolName) : base()
        {
            ToolName = toolName;
        }

        public ToolResult(string toolName, ValidationResult result) : base()
        {
            ToolName = toolName;
            IsValid = result.IsValid;
            Messages = result.Messages;
            OutputMessages = true;
            MessageType = ValidationMessageType.ValidationMessage;
        }

        public ToolResult(ValidationResult result) : base()
        {
            IsValid = result.IsValid;
            Messages = result.Messages;
            OutputMessages = true;
            MessageType = ValidationMessageType.ValidationMessage;
        }

        public string ToolName { get; set; }
        public string FunctionExecuted { get; set; }
        public bool OutputMessages { get; set; }
        public ValidationMessageType MessageType { get; set; }
        public Object Result { get; set; }
    }

    public enum ValidationMessageType
    {
        ToolMessage,
        ValidationMessage
    }
}
