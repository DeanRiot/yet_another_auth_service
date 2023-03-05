using System.IO.Ports;

namespace Sms.Ports.Serial.Providers.System.Ports.Types
{
    internal class DefaultSerial : SystemSerialType
    {
        private SerialPort _port;
        internal DefaultSerial(string port_id) =>
            _port = new SerialPort(port_id, 9600, Parity.None, 8, StopBits.None);

        internal override SerialPort Get() => _port;
    }
}
