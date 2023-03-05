using System.IO.Ports;
using Sms.Ports.Serial.Providers.System.Ports.Types;

namespace Sms.Ports.Serial.Providers.System.Ports
{
    internal class PortFactory
    {
        SystemSerialType _port;
        internal PortFactory(string port_id)=>
                    _port = new DefaultSerial(port_id);
        internal PortFactory(SerialPortConfig config)=>
                  _port = new CustomSerial(config);
        internal SerialPort GetPort() => _port.Get();
    }
}
