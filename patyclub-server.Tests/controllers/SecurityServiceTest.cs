using NUnit.Framework;
using patyclub_server.Service;
using System;
using System.Security.Cryptography;
using System.Text;

namespace patyclub_server.Test
{
    public class SecurityTest
    {
        private SecurityService _securityService;

        [SetUp]
        public void Setup()
        {
            _securityService = new SecurityService();
        }

        [Test]
        public void SHA256HashTest()
        {
            byte[] result = _securityService.string2SHA256("今天天氣真好");
            SHA256 sHA256 = SHA256.Create();
            
            Assert.AreEqual(result,sHA256.ComputeHash(Encoding.ASCII.GetBytes("今天天氣真好")));
        }
    }
}