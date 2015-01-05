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

        public string Name 
        {
            get
            {
                return this.loggerName;
            }
        }



        public void SetLevel(LogLevel level)
        {
            lock (syncObj)
            {
                this.logLevel = level;
            }
        }

        public Logger(string loggerName)
        {
            this.init(loggerName, LogLevel.NOTSET);
        }

        public Logger(string loggerName, LogLevel logLevel)
        {
            this.init(loggerName, logLevel);
        }

        private void init(string loggerName, LogLevel logLevel)
        {
            lock (syncObj)
            {
                this.loggerName = loggerName;
                this.logLevel = logLevel;
                this.handlerList = new List<IHandler>();
            }
        }

        public void AddHandler(IHandler handler)
        {
            lock (syncObj)
            {
                if (handler != null)
                {
                    this.handlerList.Add(handler);
                }
            }
        }

        public void WriteLog(LogLevel level, string message)
        {
            this.pushLog(level, message);
        }

        private void pushLog(LogLevel level, string message)
        {
            if (message == null)
            {
                //TODO change exception
                throw new Exception("Message can not be null");
            }
            StackTrace stack = new System.Diagnostics.StackTrace(true);
            // Get caller method name.
            StackFrame callerStackFrame = stack.GetFrame(2);
            string functionName = callerStackFrame.GetMethod().Name;
            Record record = new Record(this.loggerName, level, stack, message, functionName,callerStackFrame);
            foreach (var handler in handlerList)
            {
                handler.push(record);
            }
        }


        public void Critical(string message)
        {
            if (!this.canLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.pushLog(LogLevel.CRITICAL, message);
        }


        public void Error(string message)
        {
            if (!this.canLog(LogLevel.ERROR))
            {
                return;
            }
            this.pushLog(LogLevel.ERROR, message); ;
        }


        public void Warning(string message)
        {
            if (!this.canLog(LogLevel.WARNING))
            {
                return;
            }
            this.pushLog(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            if (!this.canLog(LogLevel.INFO))
            {
                return;
            }
            this.pushLog(LogLevel.INFO, message);
        }

        public void Debug(string message)
        {
            if (!this.canLog(LogLevel.DEBUG))
            {
                return;
            }
            this.pushLog(LogLevel.DEBUG, message);
        }


        private bool canLog(LogLevel level)
        {
            if (level < this.logLevel)
            {
                return false;
            }
            return true;
        }

    }
}
