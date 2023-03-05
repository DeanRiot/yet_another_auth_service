using Sms.Payload.PDU.Parts.Preparer;

namespace Sms.Payload.PDU.Parts.SCA
{
    internal class SCA
    {
        private string _sca = string.Empty;
        public SCA() => _sca = string.Empty;
        public SCA(string phone)
        {
            _sca = phone;
            _sca = _sca.GenerateGSMPhone();
        }
        public string GetSca()
        {
            if (_sca == string.Empty) return ((int)PhoneType.DEFAULT).ToString("X2");
            else return PrepareSca();
        }

        private string PrepareSca()
        {
            var sca_info_len = (((int)PhoneType.CUSTOM).ToString("X2")
                               + _sca).Length / 2;
            return sca_info_len.ToString("X2") +
                    ((int)PhoneType.CUSTOM).ToString("X2") + _sca;
        }
    }
}
