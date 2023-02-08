namespace Email.Data
{
    internal struct Connection
    {
        internal Connection(string service)
        {
            Service = service;
            Port = (int)Enums.Port.SSL;
        }
        internal Connection(string service, int port)
        {
            Service = service;
            Port = port;
        }
        private int _port = (int)Enums.Port.SSL;
        private string _service = string.Empty;
        /// <summary>
        /// Use Data.Enums.Service to set
        /// </summary>
        internal string Service
        {
            get => _service;
            set => _service =
                        value.Equals(Enums.Service.GMAIL) ||
                        value.Equals(Enums.Service.YANDER) ||
                        value.Equals(Enums.Service.MAIL_RU) ?
                        value : throw new InvalidOperationException("USE Data.Enums.Service to set this field");
        }
        /// <warning>
        /// Use TLS only for Google SMTP service
        /// </warning>
        internal int Port
        {
            get => _port;
            set
            {
                if (!(value.Equals((int)Enums.Port.SSL) || value.Equals((int)Enums.Port.TLS)))
                    throw new InvalidDataException("USE SSL OR TLS PORT ONLY");
                   
                if (value.Equals((int)Enums.Port.TLS) && Service.Equals(Enums.Service.GMAIL))
                  _port = value;
                else _port = (int)Enums.Port.SSL;
            }
        }
    }
}
