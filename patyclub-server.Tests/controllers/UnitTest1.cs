using NUnit.Framework;

namespace patyclub_server.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(1, 1);
        }
    }
}