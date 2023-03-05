namespace Sms.Payload.Parts.TPDU.PDU_TYPE.ConfigBits
{
    /// <summary>
    /// user data header included
    /// </summary>
    internal enum UDHI
    {
        MESSAGE_ONLY = 0,
        MESSAGE_WITH_HEADER=0b01000000,
    }
}
