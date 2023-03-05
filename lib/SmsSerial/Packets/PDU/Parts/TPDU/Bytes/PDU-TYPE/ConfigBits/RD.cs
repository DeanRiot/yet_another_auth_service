namespace Sms.Payload.Parts.TPDU.PDU_TYPE.ConfigBits
{
    /// <summary>
    /// Reject Duplicates
    /// </summary>
    internal enum RD
    {
        /// <summary>
        /// SMSC SEND MESSAGE
        /// WHERE DUPLICATED MR AND DA
        /// </summary>
        NO =  0b00000000,
        /// <summary>
        /// SMSC REJECT MESSAGE 
        /// WHERE DUPLICATED MR AND DA
        /// </summary>
        YES = 0b00000100
    }
}
