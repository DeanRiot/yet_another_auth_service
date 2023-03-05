using Sms.Payload.Parts.TPDU.PDU_TYPE.ConfigBits;
namespace Sms.Payload.Parts.TPDU.PDU_TYPE
{
    internal class PDU_Type
    {
        public string Generate()=>
             ((int)RP.NONE +
             (int)UDHI.MESSAGE_ONLY +
             (int)SRR.NONE +
             (int)VPF.None +
             (int)RD.NO +
             (int)MTI.SEND_FROM_MODULE).ToString("X2");
    }
}
