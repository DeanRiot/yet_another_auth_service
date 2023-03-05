using System.IO.Ports;

namespace Sms.Ports.Serial.Providers.System.Ports.Types
{
    internal abstract class SystemSerialType
    {
        internal abstract SerialPort Get();
    }
}
