namespace SmsSerialLibTests.MoqObjects.ATDevice
{
    internal static class AnswersTemplates
    {
        public const string OK = "OK \r\n";
        public const string PDU_WAIT = ">";
        public const string SENDED = "+CMGS:0 \r\n OK,";
        public const string INVALID_PDU = "ERROR: 304 \r\n";
        public const string IGNORED = "";
    }
}
