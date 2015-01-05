namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Logger : ILogger
    {
        private string loggerName;
        private LogLevel logLevel;
        private List<IHandler> handlerList;
        private object syncObj = new object();

        public Logger(string loggerName)
        {
            this.Init(loggerName, LogLevel.NOTSET);
        }

        public Logger(string loggerName, LogLevel logLevel)
        {
            this.Init(loggerName, logLevel);
        }

        public string Name 
        {
            get
            {
                return this.loggerName;
            }
        }



        public void SetLevel(LogLevel level)
        {
            lock (this.syncObj)
            {
                this.logLevel = level;
            }
        }



        public void Critical(string message)
        {
            if (!this.CanLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.PushLog(LogLevel.CRITICAL, message);
        }


        public void Error(string message)
        {
            if (!this.CanLog(LogLevel.ERROR))
            {
                return;
            }
            this.PushLog(LogLevel.ERROR, message);
        }


        public void Warning(string message)
        {
            if (!this.CanLog(LogLevel.WARNING))
            {
                return;
            }
            this.PushLog(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            if (!this.CanLog(LogLevel.INFO))
            {
                return;
            }
            this.PushLog(LogLevel.INFO, message);
        }

        public void Debug(string message)
        {
            if (!this.CanLog(LogLevel.DEBUG))
            {
                return;
            }
            this.PushLog(LogLevel.DEBUG, message);
        }

        public void AddHandler(IHandler handler)
        {
            lock (this.syncObj)
            {
                if (handler != null)
                {
                    this.handlerList.Add(handler);
                }
            }
        }

        public void WriteLog(LogLevel level, string message)
        {
            this.PushLog(level, message);
        }

        private void Init(string loggerName, LogLevel logLevel)
        {
            lock (this.syncObj)
            {
                this.loggerName = loggerName;
                this.logLevel = logLevel;
                this.handlerList = new List<IHandler>();
            }
        }

        private void PushLog(LogLevel level, string message)
        {
            if (message == null)
            {
                // TODO change exception
                throw new Exception("Message can not be null");
            }
            StackTrace stack = new System.Diagnostics.StackTrace(true);
            // Get caller method name.
            StackFrame callerStackFrame = stack.GetFrame(2);
            string functionName = callerStackFrame.GetMethod().Name;
            Record record = new Record(this.loggerName, level, stack, message, functionName, callerStackFrame);
            foreach (var handler in this.handlerList)
            {
                handler.Push(record);
            }
        }



        private bool CanLog(LogLevel level)
        {
            if (level < this.logLevel)
            {
                return false;
            }
            return true;
        }

    }
}
