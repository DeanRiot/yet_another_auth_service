using Email.Data;

namespace Email
{
    public class Sender
    {
        private Config SENDER_CONFIG;
        public Sender(string email, string password, string email_service)=>
                SENDER_CONFIG = new(email_service,email,password);
        public Sender(string email, string password, string email_service, bool USE_TLS=false) =>
                SENDER_CONFIG = new(email_service, 
                                    USE_TLS?(int) Data.Enums.Port.TLS :(int)Data.Enums.Port.SSL,
                                    email, password);
      
        public string Email {
            get => SENDER_CONFIG.Credentials.Email;
            set => SENDER_CONFIG.Credentials =
                    new (value, SENDER_CONFIG.Credentials.Password);  
        }
        public string Password
        {
            set => SENDER_CONFIG.Credentials =
                    new(SENDER_CONFIG.Credentials.Email, value);
        }
        public string EmailService
        {
            get => SENDER_CONFIG.Connection.Service;
            set => SENDER_CONFIG.Connection =
                    new(value, SENDER_CONFIG.Connection.Port);
        }
        public int Port
        {
            get => SENDER_CONFIG.Connection.Port;
            set => SENDER_CONFIG.Connection =
                    new( SENDER_CONFIG.Connection.Service, value);
        }

        public void Send()
        {
            
        } 
    }
}