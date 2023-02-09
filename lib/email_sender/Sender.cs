using Email.Data;
using Email.Senders;

namespace Email
{
    public class Sender
    {
        private Config SENDER_CONFIG;
        private IMailSender _sender;
        public Sender(string email, string password, string email_service)
        {
            SENDER_CONFIG = new(email_service, email, password);
            _sender = new SMTPSender(SENDER_CONFIG); 
        }
             
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
            set => SENDER_CONFIG.Connection = new(value);
        }
        public int Port 
        {
            get => SENDER_CONFIG.Connection.Port;
        }

        public IMailSender MailSender
        {
            get => _sender;
            set => _sender = value;
        }
        public (bool status, string reason) Send(string recepilent_email, string title, string body) =>
                        _sender.Send(recepilent_email, title, body);
        public (bool status, string reason) Send(string recepilent_email, string body) =>
                        _sender.Send(recepilent_email, body);
        public (bool status, string reason) Send(string recepilent_email, Message message) =>
                        _sender.Send(recepilent_email, message);
    }
}