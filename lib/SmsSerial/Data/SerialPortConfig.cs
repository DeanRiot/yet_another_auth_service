using Sms.Data.SerialConfig;

namespace Sms.Data
{
    public struct SerialPortConfig
    {
        public string Port { get; set; } = string.Empty;
        public BaudRate BaudRate { get; set; } = BaudRate.BAUD_9600;
        public Pairity Parity { get; set; } = Pairity.NONE;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.NONE;
        public SerialPortConfig(string Port) => this.Port = Port;
        public int ReadTimeout { get; set; } = 1000;
        public int WriteTimeout { get; set; } = 1000;
        public SerialPortConfig(string Port, BaudRate BaudRate)
        {
            this.Port = Port;
            this.BaudRate = BaudRate;
        }
        public SerialPortConfig(string Port, BaudRate BaudRate, Pairity ParityBits)
        {
            this.Port = Port;
            this.BaudRate = BaudRate;
            this.Parity = ParityBits;
        }
        public SerialPortConfig(string Port, BaudRate BaudRate, Pairity ParityBits, int DataBits)
        {
            this.Port = Port;
            this.BaudRate = BaudRate; 
            this.Parity = ParityBits;
            this.DataBits = DataBits;
        }
        public SerialPortConfig(string Port, BaudRate BaudRate, Pairity ParityBits, int DataBits, StopBits StopBits)
        {
            this.Port = Port;
            this.BaudRate = BaudRate;
            this.Parity = ParityBits;
            this.DataBits = DataBits;
            this.StopBits = StopBits;
        }
    }
}
