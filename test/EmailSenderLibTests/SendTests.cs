using Email.Senders;
using Moq;

namespace EmailSenderLibTests
{
    public class SendTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void run_send()
        {
            var MailSender = new Mock<IMailSender>(); 
            Email.Sender sender = new("test@gmail.com", "secret", Email.Data.Enums.Service.GMAIL);
            sender.MailSender = MailSender.Object;

            Assert.That(sender.MailSender, Is.EqualTo(MailSender.Object));

            sender.Send("my_mail@gmail.com","hello");
            MailSender.Verify(ms => ms.Send(It.IsAny<string>(), It.IsAny<string>()));

            sender.Send("my_mail@gmail.com", "hello_message","hello");
            MailSender.Verify(ms => ms.Send(It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>()));

            var message = new Email.Data.Message("hello_message", "hello");
            sender.Send("my_mail@gmail.com", message);
            MailSender.Verify(ms => ms.Send(It.IsAny<string>(),
                              It.Is<Email.Data.Message>((it)=>it.body.Equals(message.body))));
        }

    }
}