namespace Email.Data
{
    internal struct Config
    {
        internal Config(string service, int port, Credentials credentials)
        {
            Credentials = credentials;
            Connection = new Connection(service, port);
        }
        internal Config(string service, Credentials credentials)
        {
            Credentials = credentials;
            Connection = new Connection(service);
        }
        internal Config(string service,string email, string password)
        {
            Credentials = new Credentials(email,password);
            Connection = new Connection(service);
        }
        internal Config(string service,int port, string email, string password)
        {
            Credentials = new Credentials(email, password);
            Connection = new Connection(service, port);
        }
        internal Credentials Credentials { get; set; }
        internal Connection Connection { get; set; }
    }
}
