using Sms.Payload.PDU.Parts.Preparer;
using Sms.Payload.PDU.Parts.TPDU.Bytes;
using Sms.Payload.Parts.TPDU.PDU_TYPE;
using Sms.Payload.Parts.TPDU.PDU_DA;

namespace Sms.Payload.PDU.Parts.TPDU
{
    internal class TPDU
    {
        public string Generate(string sender_phone, string message, bool flash = false, VP validity_period = VP.None)
        {
            var PDU_T = new PDU_Type().Generate();
            var TP_MR = 0x0.ToString("X2");
            var TP_DA = new PDU_DA(sender_phone).Generate();
            var TP_PID = ((int)PID.SMS).ToString("X2");
            var TP_DCS = flash ? ((int)DCS.FLASH_UCS2).ToString("X2") : ((int)DCS.UCS2).ToString("X2");
            var TP_VP = validity_period == VP.None ? "" : ((int)validity_period).ToString("X2");
            var TP_UDL = (message.Length * 2).ToString("X2");
            var TP_UD = new UCS2().UnicodeStr2HexStr(message);

            var PDU = PDU_T + TP_MR + TP_DA + TP_PID + TP_DCS + TP_VP + TP_UDL + TP_UD;
            return PDU;
        }
    }
}
