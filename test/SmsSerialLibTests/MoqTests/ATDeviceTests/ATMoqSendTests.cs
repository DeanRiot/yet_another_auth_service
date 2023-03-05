namespace SmsSerialLibTests.MoqTests.ATDeviceTests
{
    internal class ATMoqSendTests
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

        [Test]
        public void without_csca_send_test()
        {
            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("0001000B919721436587F9000812041F04400438043204350442002100210021\u001b");
            Assert.That(dev.ReadLines(), Is.EqualTo("+CMGS:0 \r\n OK,"));
        }

        [Test]
        public void multiline_send_test()
        {
            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("0001000B919721436587F9000812041F04400438043204350442002100210021");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write($"{(char)0x1B}");
            Assert.That(dev.ReadLines(), Is.EqualTo("+CMGS:0 \r\n OK,"));
        }


        [Test]
        public void with_csca_test()
        {
            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("07919701879999F901000B919721436587F9000812041F04400438043204350442002100210021\u001b");
            Assert.That(dev.ReadLines(), Is.EqualTo("+CMGS:0 \r\n OK,"));
        }

        [Test]
        public void incorrect_cmgs_test()
        {
            dev.WriteLine("AT+CMGS=62\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("0001000B919721436587F9000812041F04400438043204350442002100210021\u001b");
            Assert.That(dev.ReadLines(), Is.EqualTo("ERROR: 304 \r\n"));
        }

        [Test]
        public void incorrect_pdu_len_test()
        {
            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("0001000B919721436587F9000812041F044004380432043504420021002100210021\u001b");
            Assert.That(dev.ReadLines(), Is.EqualTo("ERROR: 304 \r\n"));
        }

        [Test]
        public void incorrect_pdu_test()
        {
            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("07919701879999F901000B919721436587F9002812041F04400438043204350442002100210021\u001B");
            Assert.That(dev.ReadLines(), Is.EqualTo("ERROR: 304 \r\n"));

            dev.WriteLine("AT+CMGS=31\r");
            Assert.That(dev.ReadLines(), Is.EqualTo(">"));

            dev.Write("0001000B919721436587F9002812041F04400438043204350442002100210021\u001B");
            Assert.That(dev.ReadLines(), Is.EqualTo("ERROR: 304 \r\n"));
        }
    }
}
