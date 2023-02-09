namespace Email.Data
{
    internal struct Config
    {
        internal Config(string service, Credentials credentials)
        {
            Credentials = credentials;
            Connection = new Connection(service);
        }

        internal Config(string service, string email, string password) :
                       this(service, new Credentials(email, password)) { }
      
        internal Credentials Credentials { get; set; }
        internal Connection Connection { get; set; }
    }
}
