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
            pushLogMsg(logger);
            Assert.AreEqual(handler.GetRecordList().Count, 5);
        }

        [Test]
        public void TestLogLevelInfo()
        {
            var logger = createTestLogger("TestLogLevelInfo");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.INFO);
            pushLogMsg(logger);
            Assert.AreEqual(handler.GetRecordList().Count, 4);
        }

        [Test]
        public void TestLogLevelWarning()
        {
            var logger = createTestLogger("TestLogLevelWarning");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.WARNING);
            pushLogMsg(logger);
            Assert.AreEqual(handler.GetRecordList().Count, 3);
        }

        [Test]
        public void TestLogLevelError()
        {
            var logger = createTestLogger("TestLogLevelError");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.ERROR);
            pushLogMsg(logger);
            Assert.AreEqual(handler.GetRecordList().Count, 2);
        }

        [Test]
        public void TestLogLevelCritical()
        {
            var logger = createTestLogger("TestLogLevelCritical");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.CRITICAL);
            pushLogMsg(logger);
            Assert.AreEqual(handler.GetRecordList().Count, 1);
        }

        [Test]
        public void TestRecordMethodName()
        {
            var logger = createTestLogger("TestRecordMethodName");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.INFO);
            logger.Info("Test Msg");
            Assert.AreEqual(handler.GetRecordList().Count, 1);
            Assert.AreEqual(handler.GetRecordList()[0].FunctionName, "TestRecordMethodName");
        }

        [Test]
        public void TestRecordFileName()
        {
            var logger = createTestLogger("TestRecordFileName");
            var handler = new StubHandler();
            logger.AddHandler(handler);
            logger.SetLevel(LogLevel.INFO);
            logger.Info("Test Msg");
            Assert.AreEqual(handler.GetRecordList().Count, 1);
            Assert.True(handler.GetRecordList()[0].FileName.Contains("LoggerTest.cs"));
        }

        private void pushLogMsg(ILogger logger)
        {
            logger.Debug("Debug Msg");
            logger.Info("Info Msg");
            logger.Warning("Warning Msg");
            logger.Error("Error Msg");
            logger.Critical("Critical MSg");
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
            Console.WriteLine(record.FunctionName);  
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
