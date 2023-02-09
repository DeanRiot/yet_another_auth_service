using Email.Data;

namespace Email.Senders
{
    public interface IMailSender
    {
        /// <summary>Send message to recepilent</summary>
        /// <param name="recepilent_email_address">Email address in test@mail.com format</param>
        /// <param name="message_title">Email Subject</param>
        /// <param name="message_body">Email message text</param>
        /// <returns>
        /// true if send success
        /// reason if send fail
        /// </returns>
        public (bool sended,string reason) Send(string recepilent_email_address, string message_title, string message_body);

        /// <summary>Send message to recepilent</summary>
        /// <param name="recepilent_email_address">Email address in test@mail.com format</param>
        /// <param name="message_body">Email message text</param>
        /// <returns>
        /// true if send success
        /// reason if send fail
        /// </returns>
        public (bool sended, string reason) Send(string recepilent_email_address, string message_body);

        /// <summary>Send message to recepilent</summary>
        /// <param name="recepilent_email_address">Email address in test@mail.com format</param>
        /// <param name="message"></param>
        /// <returns>
        /// true if send success
        /// reason if send fail
        /// </returns>
        public (bool sended, string reason) Send(string recepilent_email_address, Message message);
    }
}
