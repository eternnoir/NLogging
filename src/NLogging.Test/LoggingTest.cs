using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLogging;
using NLogging.Exceptions;

namespace NLogging.Test
{
    [TestFixture]
    class LoggingTest
    {
        [Test]
        public void TestGetLogger()
        {
            ILogger logger1 = Logging.GetLogger("TestGetLogger"); 
            ILogger logger2 = Logging.GetLogger("TestGetLogger");
            Assert.AreSame(logger1, logger2);
        }

        [Test]
        public void TestGetDifLogger()
        {
            ILogger logger1 = Logging.GetLogger("TestGetDifLogger");
            ILogger logger2 = Logging.GetLogger("TestGetDifLogger2");
            Assert.AreNotSame(logger1, logger2);
            List<string> mailAddressList = new List<string>();
            // Add your email to List
            Dictionary<string,bool> mailAddressDict = new Dictionary<string,bool>();
            foreach (var mailAddress in mailAddressList)
            {
                var mailAddr = mailAddress.ToLower().Trim();
                if (!mailAddressDict.ContainsKey(mailAddr))
                {
                    mailAddressDict.Add(mailAddr, true);
                }
                continue;
            }

            foreach (var uniMailAddress in mailAddressDict.Keys)
            {
                System.Console.WriteLine(uniMailAddress);
            }
        }

    }
}
