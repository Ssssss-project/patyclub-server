using NUnit.Framework;
using patyclub_server.ForTestService;

namespace patyclub_server.Test2222
{
    public class Test2222
    {
        private TestService _testService;
        [SetUp]
        public void Setup()
        {
            _testService = new TestService();
        }

        [Test]
        public void CocoTest()
        {
            // _testService.concateTTT("123", "456");
            Assert.AreEqual(_testService.concateTTT("123", "456"), "123056");
            Assert.Pass();
        }
    }
}