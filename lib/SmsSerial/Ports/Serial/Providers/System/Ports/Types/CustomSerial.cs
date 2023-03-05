using System.IO.Ports;

namespace Sms.Ports.Serial.Providers.System.Ports.Types
{
    internal class CustomSerial : SystemSerialType
    {
        private SerialPort _port;
        internal CustomSerial(SerialPortConfig config)
        {
            _port = new SerialPort()
            {
                BaudRate = (int)config.BaudRate,
                DataBits = config.DataBits,

                Parity = ConfigParity(config),

                StopBits = ConfigStopBits(config),

                PortName = config.Port,

                ReadTimeout = config.ReadTimeout,

                WriteTimeout = config.WriteTimeout
            };
        }
        private static StopBits ConfigStopBits(SerialPortConfig config) =>
              config.StopBits == Data.SerialConfig.StopBits.ONE ? StopBits.One :
              config.StopBits == Data.SerialConfig.StopBits.TWO ? StopBits.Two :
              StopBits.None;

        private static Parity ConfigParity(SerialPortConfig config) =>
            config.Parity == Data.SerialConfig.Pairity.ODD ? Parity.Odd :
            config.Parity == Data.SerialConfig.Pairity.EVEN ? Parity.Even :
            Parity.None;
        internal override SerialPort Get() => _port;
    }
}
