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

        [Test]
        public void TestLoggerNameDuplicateException()
        {
            ILogger logger1 = Logging.Instance.GetLogger("LoggerName1");
            ILogger logger2 = new Logger("LoggerName1");
            try
            {
                Logging.Instance.AddLogger(logger2);
                Assert.True(false);
            }
            catch (LoggerNameDuplicateException ex)
            {
                Assert.True(true);
            }
        }
    }
}
