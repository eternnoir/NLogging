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
            ILogger logger1 = Logging.Instance.GetLogger("TestGetLogger"); 
            ILogger logger2 = Logging.Instance.GetLogger("TestGetLogger");
            Assert.AreSame(logger1, logger2);
        }

        [Test]
        public void TestGetDifLogger()
        {
            ILogger logger1 = Logging.Instance.GetLogger("TestGetDifLogger");
            ILogger logger2 = Logging.Instance.GetLogger("TestGetDifLogger2");
            Assert.AreNotSame(logger1, logger2);
        }

    }
}
