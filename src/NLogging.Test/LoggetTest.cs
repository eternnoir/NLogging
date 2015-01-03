using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLogging;

namespace NLogging.Test
{
    [TestFixture]
    class LoggetTest
    {
        [Test]
        public void TestLoggerName()
        {
            var loggerName ="TestLogger1"; 
            var logger =  Logging.Instance.GetLogger(loggerName);
            Assert.AreEqual(loggerName, logger.Name);
        }
    }
}
