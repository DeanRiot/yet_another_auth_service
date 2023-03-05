using Sms.Payload.PDU.Parts.SCA;
using Sms.Payload.PDU.Parts.TPDU;

namespace Sms.Payload.PDU
{
    internal class PDUGenerator:IPacketGenerator
    {
        readonly string _csca;
        readonly string _senderPhone;
        readonly string _message;
        readonly bool _flash;

        public PDUGenerator(string senderPhone, string message, bool flash = false, string csca = "")
        {
            SCA _sca_data_preparer = csca.Equals("") ? new() : new(csca);
            _csca = _sca_data_preparer.GetSca();
            _senderPhone = senderPhone;
            _message = message;
            _flash = flash;
        }
        public string GetPacket(out int message_length)
        {
            TPDU PDU_Generator = new();
            var PDU = PDU_Generator.Generate(_senderPhone, _message,_flash);
            message_length = PDU.Length / 2;
            return _csca + PDU;
        }
    }
}
