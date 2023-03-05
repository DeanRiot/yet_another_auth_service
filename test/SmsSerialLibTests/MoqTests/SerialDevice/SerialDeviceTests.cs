namespace SmsSerialLibTests.MoqTests.SerialDevice
{
    internal class SerialDeviceTests
    {
        SerialDeviceMoq dev; 
        [SetUp]
        public void SetUp()=> dev = new SerialDeviceMoq();

        [TearDown]
        public void TearDown() => dev.Dispose();
        

        [Test]
        public void close_by_closed_throw_e() => Assert.Throws<Exception>(() => { dev.Close(); });

        [Test]
        public void is_opened_change_test()
        {
            Assert.That(dev.IsOpened(),Is.False);
            dev.Open();
            Assert.That(dev.IsOpened(),Is.True);
            dev.Close();
            Assert.That(dev.IsOpened(),Is.False);
        }

        [Test]
        public void read_operation_throws_e_if_closed()
        {
            Assert.Throws<Exception>(() => { dev.ReadLines(); });
            Assert.Throws<Exception>(() => { dev.ReceiveLine(); });
        }
        
        [Test]
        public void write_operation_throws_e_if_closed()
        {
            Assert.Throws<Exception>(() => { dev.Write("123456"); });
            Assert.Throws<Exception>(() => { dev.WriteLine("12345"); });
        }

        [Test]
        public void flush_test()
        {
            Assert.Throws<Exception>(() => { dev.Flush(); });
            dev.Open();
            dev.Write("123456");
            dev.Write("123456");
            Assert.That(dev.ReceiveLine(), Is.EqualTo("123456"));
            dev.Flush();
            Assert.That(dev.ReceiveLine(), Is.EqualTo(""));
        }

        [Test]
        public void writeline_add_endl()
        {
            dev.Open();
            dev.WriteLine("123456");
            var data = dev.ReadLines();
            Assert.That(data, Is.EqualTo("123456\n"));
        }
    }
}
