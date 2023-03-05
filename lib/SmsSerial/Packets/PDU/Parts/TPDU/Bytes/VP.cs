namespace Sms.Payload.PDU.Parts.TPDU.Bytes
{
    /// <summary>
    /// Validity Period
    /// </summary>
    internal enum VP
    {
        None = 0,
        HOUR = 0x0,
        THREE_HOURS = 0x23,
        SIX_HOURS = 0x47,
        TWENTY_HOURS = 0x8F,
        DAY = 0xA7,
        MOUNTH = 0xC4,
        MAX_VALUE = 0xFF
    }
}
