namespace SmsSerialLibTests.MoqTests.ATDeviceTests
{
    public class ATDeviceCommands
    {
        MoqObjects.SerialDeviceMoq dev;

        [SetUp]
        public void SetUp()
        {
            dev = new MoqObjects.ATDevice.ATDeviceMoq();
            dev.Open();
        }
        [TearDown]
        public void TearDown()
        {
            dev.Close();
        }

        [TestCase("ATZ\r")]
        [TestCase("AT\r")]
        [TestCase("AT^CURC=0\r")]
        [TestCase("AT+CMGF=0\r")]
        public void valid_at_command_test(string cmd)
        {
            dev.Open();
            dev.Write(cmd);
            Assert.That(dev.ReadLines(), Is.EqualTo("OK \r\n"));
        }

        [Test]
        public void invalid_at_command_test()
        {
            dev.Write("ATS\r\n");
            Assert.That(dev.ReadLines(), Is.EqualTo(""));
        }

        [TestCase("FF")]
        [TestCase("2A")]
        [TestCase("0001000B919721436587F9000812041F04400438043204350442002100210021")]
        public void cmgs_ignore_invalid_typed_len_test(string data)
        {
            dev.WriteLine($"AT+CMGS={data}\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(""));
        }
    }
}