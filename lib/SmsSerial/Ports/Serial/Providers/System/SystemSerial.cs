using System.IO.Ports;

namespace Sms.Ports.Serial.Providers.System
{
    public class SystemSerial : ISerialPort
    {
        SerialPort _port;
        public SystemSerial(SerialPort port) => _port = port;

        public bool IsOpened() => _port.IsOpen;

        public void Open()
        {
            try
            {
                _port.Open();
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }

        public void Close()
        {
            if (_port.IsOpen) _port.Close();
        }

        public byte[] ReceiveBytes()
        {
            List<byte> bytes = new();
            try
            {
                while (_port.BytesToRead != 0)
                    bytes.Add((byte)_port.ReadByte());
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
            return bytes.ToArray();
        }

        public byte ReceiveByte()
        {
            if (_port.IsOpen) return (byte)_port.ReadByte();
            else throw new PortFailureException("Port closed");
        }

        public void Write(byte[] data)
        {
            try
            {
                _port.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }
        public void Write(string data)
        {
            try
            {
                _port.Write(data);
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }
        public void WriteLine(string data)
        {
            try
            {
                _port.WriteLine(data);
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }

        public string ReceiveLine()
        {
            try
            {
                return _port.ReadLine();
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }

        public void Flush()
        {
            try
            {
                _port.DiscardOutBuffer();
                _port.DiscardInBuffer();
            }
            catch (Exception e)
            {
                throw new PortFailureException(e.Message, e);
            }
        }
        public string ReadLines() => _port.ReadExisting();
        public void Dispose() => _port.Dispose();
    }
}
