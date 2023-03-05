using System.Text;

namespace Sms.Payload.PDU.Parts.Preparer
{
    internal class UCS2
    {
        //Encode UTF as UCS2 bytes 
        internal string UnicodeStr2HexStr(string strMessage)
        {
            byte[] ba = Encoding.BigEndianUnicode.GetBytes(strMessage);
            string strHex = BitConverter.ToString(ba);
            strHex = strHex.Replace("-", "");
            return strHex;
        }

        internal string HexStr2UnicodeStr(string strHex)
        {
            byte[] ba = HexStr2HexBytes(strHex);
            return HexBytes2UnicodeStr(ba);
        }

        // Decode UCS2 bytes as UTF  
        internal string HexBytes2UnicodeStr(byte[] ba)
        {
            var strMessage = Encoding.BigEndianUnicode.GetString(ba, 0, ba.Length);
            return strMessage;
        }

        internal byte[] HexStr2HexBytes(string strHex)
        {
            strHex = strHex.Replace(" ", "");
            int nNumberChars = strHex.Length / 2;
            byte[] aBytes = new byte[nNumberChars];
            using (var sr = new StringReader(strHex))
            {
                for (int i = 0; i < nNumberChars; i++)
                    aBytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return aBytes;
        }
    }
}
