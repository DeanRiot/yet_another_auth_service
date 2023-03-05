
using Sms.Payload;
using Sms.Payload.PDU;
using Sms.Ports.Serial;

namespace Sms.Senders
{
    public sealed class ATCommandsDevice : Sender
    {
        public ATCommandsDevice(ISerialPort port) : base(port) { }
        public ATCommandsDevice(string port_id) : base(port_id) { }
        protected override void Send(object[] packet)
        {
            foreach (string cmd in packet)
            {
                Port.Write(cmd);
                Thread.Sleep(50);
                var readed = Port.ReadLines();
                if (!(readed.Contains("OK") || readed.Contains('>') || readed.Contains("CMS")))
                {
                    throw new ProtocolException($"Device answer is not valid: {readed}");
                }
            }
        }

        protected override string[] PreparePacket(string phone, string message,bool flash = false, string sca_phone="")
        {
            IPacketGenerator generator = sca_phone.Equals("")?
                                 new PDUGenerator(phone, message):
                                 new PDUGenerator(phone, message, flash, sca_phone);
            string packet = generator.GetPacket(out var pdu_len);
            List<string> payload = GetCommands(packet, pdu_len);
            return payload.ToArray();
        }

        private static List<string> GetCommands(string packet, int pdu_len)
        {
            var payload = new List<string>() {
                "ATZ\r",//load usr cfg
                "AT^CURC=0\r",//disable RSSI output
                "AT+CMGF=0\r",//set pdu send mode
                $"AT+CMGS={pdu_len}\r",//set message len
                $"{packet}\u001b" //pdu
            };
            return payload;
        }
    }
}
