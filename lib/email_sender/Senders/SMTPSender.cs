using Email.Data;
using System.Net;
using System.Net.Mail;

namespace Email.Senders
{
    internal class SMTPSender : IMailSender
    {
        Config _config;
        SmtpClient _smtp;
        public SMTPSender(Config config) => Config = config;

        public Config Config
        {
            get => _config;
            set => _config = value;
        }

        public (bool sended, string reason) Send(string recepilent_email_address, string message_body) =>
            Send(recepilent_email_address, "", message_body);

        public (bool sended, string reason) Send(string recepilent_email_address, Message message) =>
            Send(recepilent_email_address, message.title, message.body);


        public (bool sended, string reason) Send(string recepilent_email_address,
                                    string message_title,
                                    string message_body)
        {
            ConfigureSender();
            try
            {
                var message = CreateMessage(recepilent_email_address,
                                            message_title, message_body);
                _smtp.Send(message);
            }
            catch (Exception e) { return (false, e.Message); }
            finally { _smtp.Dispose(); }
            return (true, "");
        }
        private void ConfigureSender()
        {
            _smtp = new SmtpClient()
            {
                Host = _config.Connection.Service,
                Port = _config.Connection.Port,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_config.Credentials.Email,
                                                    _config.Credentials.Password),
                Timeout = 5000,
                EnableSsl = true
            };
            _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        private MailMessage CreateMessage(string recepilent_email_address,
                                          string message_title,
                                          string message_body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_config.Credentials.Email);
            message.CC.Add(_config.Credentials.Email);
            message.To.Add(recepilent_email_address);
            message.Subject = message_title;
            message.Body = message_body;
            return message;
        }
    }
}

