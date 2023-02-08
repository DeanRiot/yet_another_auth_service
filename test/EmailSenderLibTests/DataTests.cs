namespace EmailSenderLibTests
{
    public class DataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void correct_data_is_saved()
        {
            Email.Sender sender = new("test@gmail.com", "secret", Email.Data.Enums.Service.GMAIL);
            Assert.That(sender.Email, Is.EqualTo("test@gmail.com"));
            Assert.That(sender.EmailService, Is.EqualTo("smtp.gmail.com"));
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.SSL));
        }

   

        [Test]
        public void TLS_connection_correct_for_google_service_only()
        {
            //correct entry
            Email.Sender sender = new("test@gmail.com", "secret", Email.Data.Enums.Service.GMAIL,true);
            Assert.That(sender.Port,Is.EqualTo((int)Email.Data.Enums.Port.TLS));
            
            //incorrect entry set SLL
            sender = new("test@mail.ru", "secret", Email.Data.Enums.Service.MAIL_RU, true);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.SSL));

            sender = new("test@yandex.ru", "secret", Email.Data.Enums.Service.YANDER, true);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.SSL));
        }

        [TestCase("")]
        [TestCase("null")]
        [TestCase("89030815231")]
        [TestCase(null)]
        public void incorrect_service_throw_invalid_data_exception(string service)
        {
            //On create
            try
            {
                new Sender("test@mail.com", "secret", service);
                Assert.Fail($"{service} was not throw exception");
            }
            catch { Assert.Pass(); }

            //On redefinition
            try
            {
                Sender sender = new Sender("test@mail.com", "secret", Email.Data.Enums.Service.GMAIL);
                sender.EmailService = service;
                Assert.Fail($"{service} was not throw exception");
            }
            catch {Assert.Pass();}
        }

        [TestCase("testgmail.com")]
        [TestCase("test@gmail")]
        [TestCase("89030815231")]
        [TestCase("")]
        public void wrong_email_address_throw_exception(string email)
        {
            //On create
            try
            {
                new Sender(email, "secret", Email.Data.Enums.Service.GMAIL);
                Assert.Fail($"{email} was not throw exception");
            }
            catch{Assert.Pass();}

            //On redefinition
            try
            {

                Sender sender = new("test@gmail", "secret", Email.Data.Enums.Service.GMAIL);
                sender.Email = email;
                Assert.Fail($"{email} was not throw exception");
            }
            catch { Assert.Pass(); }
        }
    }
}