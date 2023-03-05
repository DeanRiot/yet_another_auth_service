using Sms.Ports.Serial;

namespace SmsSerialLibTests.MoqObjects
{
    internal class SerialDeviceMoq : ISerialPort
    {
        bool state;
        protected Queue<string> answer = new();
        public Queue<string> Log = new();

        public void Open() => state = true;
        public void Close()
        {
            if (!state) throw new Exception();
            state = false;
        }
        public bool IsOpened() => state;
        public void Flush()
        {
            if (!state) throw new Exception();
            answer.Clear();
        }
        public virtual string ReceiveLine()
        {
            if (!state) throw new Exception();
            if(!answer.TryDequeue(out string val))
                val = string.Empty;
            Log.Enqueue(val);
            return val;
        }
        public virtual string ReadLines()
        {
            if (!state) throw new Exception();
            var val = string.Concat(answer);
            answer.Clear();
            return val;
        }
        public virtual void Write(string data)
        {
            if (!state) throw new Exception();
            
            answer.Enqueue(data);
            Log.Enqueue(data);
        }
        public virtual void WriteLine(string data)
        {
            if (!state) throw new Exception();
            answer.Enqueue(data + "\n");
            Log.Enqueue(data + "\n");
        }
        public byte ReceiveByte() =>
            throw new NotImplementedException();
        public byte[] ReceiveBytes() =>
             throw new NotImplementedException();
        public void Write(byte[] data) =>
            throw new NotImplementedException();
        public void Dispose() { state = false; }
    }
}
