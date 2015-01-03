using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLogging;

namespace NLogging.Test
{
    [TestFixture]
    class LoggerTest
    {
        [Test]
        public void TestLoggerName()
        {
            var loggerName ="TestLogger1"; 
            var logger =  Logging.Instance.GetLogger(loggerName);
            Assert.AreEqual(loggerName, logger.Name);
        }

        [Test]
        public void TestAddHandler()
        {
            var loggerName = "TestAddHandler";
            var logger = Logging.Instance.GetLogger(loggerName);
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.Info("TestMsg");
            var recordList = handler.GetRecordList();
            Assert.AreEqual(recordList.Count, 1);
        }

        [Test]
        public void TestLogLevelDebug()
        {
            var logger = createTestLogger("TestLogLevelDebug");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.DEBUG);
            logger.Debug("Debug Msg");
            logger.Info("Info Msg");
            logger.Warning("Warning Msg");
            logger.Error("Error Msg");
            logger.Critical("Critical MSg");
            logger.WriteLog(LogLevel.NOTSET, "Noset Msg");
            Assert.AreEqual(handler.GetRecordList().Count, 5);
        }

        private ILogger createTestLogger(string loggerName)
        {
            var logger = Logging.Instance.GetLogger(loggerName);
            return logger;
        }
    }

    class StubHandler : Handler
    {
        private List<Record> recordList;

        public StubHandler()
        {
            this.recordList = new List<Record>();
        }

        public override void push(Record record)
        {
            recordList.Add(record);
        }

        public override void flush()
        {
            throw new NotImplementedException();
        }

        public List<Record> GetRecordList()
        {
            return this.recordList;
        }


    }
}
