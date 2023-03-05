using Sms.Ports.Serial.Providers.System;
using Sms.Ports.Serial.Providers.System.Ports;

namespace Sms.Ports.Serial
{
    internal class SystemSerialFactory
    {
        private ISerialPort _port;
        internal SystemSerialFactory(string port_id)
        {
            PortFactory _factory = new (port_id);
            _port = new SystemSerial(_factory.GetPort());
        }
        internal SystemSerialFactory(SerialPortConfig cfg)
        {
            PortFactory _factory = new(cfg);
            _port = new SystemSerial(_factory.GetPort());
        }
        internal ISerialPort GetPort() => _port;
     
    }
}
