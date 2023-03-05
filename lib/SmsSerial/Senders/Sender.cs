using Sms.Ports.Serial;
using System.Text.RegularExpressions;

namespace Sms.Senders
{
    public abstract class Sender
    {
        public ISerialPort Port { get; set; }
        public Sender(ISerialPort port) => Port = port;
        public Sender(string port_id) =>
                    Port = new SystemSerialFactory(port_id).GetPort();

        public void Send(string message, string phone_number,bool flash = false, string sca_phone="")
        {
            if (!(sca_phone.Equals("")) && !ValidatePhone(sca_phone)) throw new InvalidPhoneException();
            if (!ValidatePhone(phone_number)) throw new InvalidPhoneException();
            OpenPortAndFlush();
            var packet = PreparePacket(phone_number, message, flash, sca_phone);
            Send(packet);
            Port.Close();
        }
        protected abstract object[] PreparePacket(string phone_number, string message,bool flash = false, string sca_phone="");
        protected abstract void Send(object[] packet);
        private void OpenPortAndFlush()
        {
            if (!Port.IsOpened()) Port.Open();
            Port.Flush();
        }

        protected virtual bool ValidatePhone(string phone_number) =>
            Regex.IsMatch(phone_number, @"^[7]\d{10}$");
    }
}
