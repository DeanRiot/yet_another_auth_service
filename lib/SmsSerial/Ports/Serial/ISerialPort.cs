using System.IO.Ports;

namespace Sms.Ports.Serial
{
    public interface ISerialPort : IDisposable
    {
        public static string[] GetPorts() => SerialPort.GetPortNames();
        void Write(byte[] data);
        void Write(string data);
        void WriteLine(string data);
        byte[] ReceiveBytes();
        byte ReceiveByte();
        string ReceiveLine();
        string ReadLines();
        void Open();
        void Close();
        void Flush();
        bool IsOpened();
    }
}
