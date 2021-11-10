using NUnit.Framework;
using patyclub_server.Service;
using System.Collections.Generic;
using MimeKit;

namespace patyclub_server.Test
{
    public class MailTest
    {
        private TestService _testService;
        private MailService _mailService;
        [SetUp]
        public void Setup()
        {
            _testService = new TestService();
            _mailService = new MailService();
        }

        [Test]
        public void CocoTest()
        {
            // _testService.concateTTT("123", "456");
            Assert.AreEqual(_testService.concateTTT("123", "456"), "123056");
            Assert.Pass();
        }

        [Test]
        public void sendOneMailTest()
        {
            List<MailUser> userList = new List<MailUser>();
            userList.Add(new MailUser("AA", "charles01270@gmail.com"));
            userList.Add(new MailUser("BB", "smile022592@gmail.com"));
            _mailService.sendMail(
                _mailService.Mail(
                    userList,
                    "TEST1",
                    @"HI HEAD
                    HI SECOND LINE
                    AAAA
                    ~~")
            );
            Assert.Pass();
        }

        [Test]
        public void sendMultiMailTest()
        {
            List<MailUser> userList = new List<MailUser>();
            userList.Add(new MailUser("AA", "charles01270@gmail.com"));
            userList.Add(new MailUser("BB", "smile022592@gmail.com"));

            List<MimeMessage> messageList = new List<MimeMessage>();
            messageList.Add(
                _mailService.Mail(
                    userList,
                    "TEST1",
                    @"HI HEAD
                    HI SECOND LINE
                    AAAA
                    ~~")
            );
            messageList.Add(
                _mailService.Mail(
                    userList,
                    "TEST2",
                    @"HI HEAD
                    HI SECOND LINE
                    BBBB
                    ~~")
            );
            _mailService.sendMail(
                messageList
            );
            // _mailService.sendMail2();
            Assert.Pass();
        }
    }
}