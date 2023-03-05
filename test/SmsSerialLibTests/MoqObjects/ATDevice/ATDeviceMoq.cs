using System.Text.RegularExpressions;

namespace SmsSerialLibTests.MoqObjects.ATDevice
{

    internal class ATDeviceMoq : SerialDeviceMoq
    {
        static bool WaitNext = false;
        static int NextLen = 0;
        static int IncomingBytes = 0;
        public override void Write(string data)
        {
            var ans = GetAnswer(data);
            answer.Enqueue(ans);
            Log.Enqueue(data);
            Log.Enqueue(ans);
        }
        public override void WriteLine(string data)
        {
            var ans = GetAnswer(data+"\n");
            answer.Enqueue(ans);
            Log.Enqueue(data);
            Log.Enqueue(ans);
        }

        private string GetAnswer(string data)
        {
            if (WaitNext) return PDUCheck(data);
            return CheckData(data);
        }
        private string CheckData(string data)
        {
            switch (data)
            {
                case "AT\r":
                    return AnswersTemplates.OK;
                case "ATZ\r":
                    return AnswersTemplates.OK;
                case "AT^CURC=0\r":
                    return AnswersTemplates.OK;
                case "AT+CMGF=0\r":
                    return AnswersTemplates.OK;
                case string a when a.Contains("AT+CMGS="):
                    {
                        if (!int.TryParse(a.Substring(8), out NextLen))
                            return AnswersTemplates.IGNORED;
                        WaitNext = true;
                        return AnswersTemplates.PDU_WAIT;
                    }
                default: return AnswersTemplates.IGNORED;
            }
        }

        string result = AnswersTemplates.INVALID_PDU;
        private string PDUCheck(string data)
        {
            if (!PDULenCheck(data)) return AnswersTemplates.INVALID_PDU;
            result = data.Length>1 && cmdValidation(data)? AnswersTemplates.SENDED: result;
            if (data.Contains((char)0x1B))
            {
                if (!NextLen.Equals(IncomingBytes / 2)) 
                   result = AnswersTemplates.INVALID_PDU;
                SetDefaultState();
                return result;
            }
            return AnswersTemplates.PDU_WAIT;
        }

        private bool PDULenCheck(string data)
        {
            int substractBytesLen = data.StartsWith("00") ? 3 : 
                                    data.StartsWith("0791") ? 17 : 0;

            IncomingBytes += data.Length - substractBytesLen;
            if (IncomingBytes/2 <= NextLen) return true;

            SetDefaultState();
            return false;         
        }

        private static void SetDefaultState()
        {
            WaitNext = false;
            IncomingBytes = 0;
            NextLen = 0;
        }

        private static bool cmdValidation(string a)
        {
            if (a.StartsWith("00")) return WithoutCSCA(a);
            return WithCSCA(a);
        }

        private static bool WithCSCA(string a)
        {
            string pattern = @"^.{16}01000B91\d7\d{8}F.00((08)|(18)).*$";
            return (Regex.IsMatch(a, pattern) && MessageLenIsMatchUDLByte(a, 40));
        }

        private static bool WithoutCSCA(string a)
        {
            string pattern = @"^0001000B91\d7\d{8}F.00((08)|(18)).*$";
            return (Regex.IsMatch(a, pattern) && MessageLenIsMatchUDLByte(a, 26));
        }

        private static bool MessageLenIsMatchUDLByte(string a, int udlPlace)
        {
            var udl = a.Substring(udlPlace, 2);
            var charCount = Convert.ToInt32(udl, 16);
            var len = a.Substring(udlPlace + 2).Length / 2;
            return len == charCount;
        }
    }
}
