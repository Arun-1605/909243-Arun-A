using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerComm_should
    {
        [Test]
        public void sendMail()
        {
            Mock<IMailSender> iplayerMappermock = new Mock<IMailSender>();
            var iplayerMapper = iplayerMappermock.Object;
            var customercomm = new CustomerCom(iplayerMapper);
            var actual = customercomm.SendMailCustomer();
            Assert.That(actual, Is.True);
        }

    }
}