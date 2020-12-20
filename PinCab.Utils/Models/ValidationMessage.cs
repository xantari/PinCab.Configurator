namespace PinCab.Utils.Models
{
    public class ValidationMessage
    {
        public ValidationMessage() {}

        public ValidationMessage(string message, MessageLevel level)
        {
            Message = message;
            Level = level;
        }

        public string Message { get; set; }
        public MessageLevel Level { get; set; }
    }


}