using Sms.Payload.PDU.Parts.Preparer;
using System.ComponentModel.DataAnnotations;

namespace Sms.Payload.Parts.TPDU.PDU_DA
{
    /// <summary>
    /// Sender phone with metadata
    /// </summary>
    internal class PDU_DA
    {
        string _phone;
        public PDU_DA(string phone)
        {
            _phone = phone.GenerateGSMPhone();
        }
        public string Generate()
        {
            var len = (_phone.Length-1).ToString("X2");
            return len + ((int)PhoneType.CUSTOM).ToString("X2") + _phone;
        }
    }
}
