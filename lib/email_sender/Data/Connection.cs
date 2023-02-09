namespace Email.Data
{
    internal struct Connection
    {
        internal Connection(string service) => Service = service;

        private int _port = (int)Enums.Port.DEFAULT;
        private string _service = string.Empty;
        
        /// <summary>
        /// Use Data.Enums.Service to set
        /// </summary>
        internal string Service
        {
            get => _service;
            set
            {
                _service =
                        value.Equals(Enums.Service.YANDEX) ||
                         value.Equals(Enums.Service.GMAIL)||
                        value.Equals(Enums.Service.MAIL_RU) ?
                        value : throw new InvalidOperationException("USE Data.Enums.Service to set this field");
                
                _port = value.Equals(Enums.Service.YANDEX)?(int)Enums.Port.YANDEX_PORT:(int)Enums.Port.DEFAULT;
            } 
        }

        internal int Port
        {
            get => _port;
        }
    }
}
