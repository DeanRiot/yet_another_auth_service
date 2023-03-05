namespace Sms.Exeptions
{
    [Serializable]
    public class PortFailureException : Exception
    {
        public PortFailureException() { }
        public PortFailureException(string message) : base(message) { }
        public PortFailureException(string message, Exception inner)
        : base(message, inner) { }
    }
}
