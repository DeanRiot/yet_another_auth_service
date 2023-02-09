using Castle.Components.DictionaryAdapter.Xml;

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
            Email.Sender sender = new("test@gmail.com", "secret", Email.Data.Enums.Service.MAIL_RU);
            Assert.That(sender.Email, Is.EqualTo("test@gmail.com"));
            Assert.That(sender.EmailService, Is.EqualTo("smtp.mail.ru"));
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));
        }


        [Test]
        public void set_data_by_property()
        {
            Sender sender = new("test@mail.ru", "secret", Email.Data.Enums.Service.MAIL_RU);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));
            
            //correct set service
            sender.EmailService = Email.Data.Enums.Service.YANDEX;
            Assert.That(sender.EmailService, Is.EqualTo(Email.Data.Enums.Service.YANDEX));
            
            //incorrect set service
            try
            {
                sender.EmailService = "Yandex";
                Assert.Fail("Incorrect service set not throw exception");
            }
            catch { Assert.Pass(); }

            //correct Email insert
            sender.Email = "test@mail.ru";
            Assert.That(sender.Email, Is.EqualTo("test@mail.ru"));

            //incorrect signature
            try
            {
                sender.Email = "testgmail.com";
                Assert.Fail("Incorrect email signature not throw exception");
            }
            catch { Assert.Pass();}
        }
       [Test]
        public void Port_set_by_service()
        {
            Sender sender;

            //set in ctor
            sender = new("test@yandex.ru", "secret", Email.Data.Enums.Service.YANDEX);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.YANDEX_PORT));

            sender = new("test@yandex.ru", "secret", Email.Data.Enums.Service.MAIL_RU);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));

            sender = new("test@yandex.ru", "secret", Email.Data.Enums.Service.GMAIL);
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));

            //set by props
            sender.EmailService = Email.Data.Enums.Service.YANDEX;
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.YANDEX_PORT));

            sender.EmailService = Email.Data.Enums.Service.MAIL_RU;
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));

            sender.EmailService = Email.Data.Enums.Service.GMAIL;
            Assert.That(sender.Port, Is.EqualTo((int)Email.Data.Enums.Port.DEFAULT));
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