namespace Sms.Payload.Parts.TPDU.PDU_TYPE.ConfigBits
{
    /// <summary>
    /// Validity Period Format
    /// </summary>
    internal enum VPF
    {
        None     = 0b00000000,
        Relative = 0b00010000,
        Absolute = 0b00011000,
    }
}
