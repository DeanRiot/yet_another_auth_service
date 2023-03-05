namespace Sms.Exeptions
{
    public class InvalidPhoneException:Exception
    {
        public InvalidPhoneException() { }
        public InvalidPhoneException(string message) : base(message) { }
        public InvalidPhoneException(string message, Exception inner)
        : base(message, inner) { }
    }
}
