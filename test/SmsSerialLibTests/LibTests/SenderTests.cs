using Sms.Exeptions;
using Sms.Senders;
using SmsSerialLibTests.MoqObjects.ATDevice;

namespace SmsSerialLibTests.LibTests
{
    internal class SenderTests
    {

        [Test]
        public void check_phone_validation()
        {
            SerialDeviceMoq dev = new ATDeviceMoq();

            Sender sender = new ATCommandsDevice(dev);
            Assert.Throws<InvalidPhoneException>(() => { sender.Send("", "89911111111"); });
            Assert.Throws<InvalidPhoneException>(() => { sender.Send("", "+79911111111"); });
            Assert.Throws<InvalidPhoneException>(() => { sender.Send("", "9911111111"); });
        }

        [Test]
        public void send_test()
        {
            SerialDeviceMoq dev = new ATDeviceMoq();
            Sender sender = new ATCommandsDevice(dev);

            sender.Send("Hello World!!!", "79964100989");
            foreach(string cmd in dev.Log)
            Console.WriteLine(cmd);

            sender.Send("Hello World!!!", "79964100989", sca_phone:"79964100989");
            foreach (string cmd in dev.Log)
                Console.WriteLine(cmd);

            sender.Send("Hello World!!!", "79964100989", flash:true, sca_phone: "79964100989");
            foreach (string cmd in dev.Log)
                Console.WriteLine(cmd);
        }

        [Test]
        public void device_incorrect_answer_throws_e()
        {
            SerialDeviceMoq dev = new SerialDeviceMoq();
            Sender sender = new ATCommandsDevice(dev);

            Assert.Throws<ProtocolException>(() => { sender.Send("Hello World!!!", "79964100989"); });
        }

        [Test]
        public void incorrect_csca_phone_throw_e()
        {
            SerialDeviceMoq dev = new ATDeviceMoq();
            Sender sender = new ATCommandsDevice(dev);

            Assert.Throws<InvalidPhoneException>(() => { sender.Send("Hello World!!!", "79964100989",sca_phone:"8911111111"); });
            Assert.Throws<InvalidPhoneException>(() => { sender.Send("Hello World!!!", "79964100989", sca_phone: "+7911111111"); });
            Assert.Throws<InvalidPhoneException>(() => { sender.Send("Hello World!!!", "79964100989", sca_phone: "abcdef"); });
        }
    }
}
