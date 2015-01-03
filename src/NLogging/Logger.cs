﻿namespace NLogging
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

        public string Name 
        {
            get
            {
                return this.loggerName;
            }
        }
        
        /// <summary>
        /// Log level property
        /// </summary>
        public LogLevel Level
        {
            get
            {
                return this.logLevel;
            }
            set
            {
                this.logLevel = value;
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
            this.loggerName = loggerName;
            this.logLevel = logLevel;
            this.handlerList = new List<IHandler>();
        }

        public void AddHandler(IHandler handler)
        {
            if (handler != null)
            {
                this.handlerList.Add(handler);
            }
        }

        public void WriteLog(LogLevel level, string message)
        {
            if (message == null)
            {
                //TODO change exception
                throw new Exception("Message can not be null");
            }
            StackTrace stack = new System.Diagnostics.StackTrace(true);
            string functionName = stack.GetFrame(1).GetMethod().Name;
            Record record = new Record(this.loggerName, level, stack, message, functionName);
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
            this.WriteLog(LogLevel.CRITICAL, message);
        }

        public void Warning(string message)
        {
            if (!this.canLog(LogLevel.WARNING))
            {
                return;
            }
            this.WriteLog(LogLevel.WARNING, message);
        }

        public void Info(string message)
        {
            if (!this.canLog(LogLevel.INFO))
            {
                return;
            }
            this.WriteLog(LogLevel.INFO, message);
        }

        public void Debug(string message)
        {
            if (!this.canLog(LogLevel.DEBUG))
            {
                return;
            }
            this.WriteLog(LogLevel.CRITICAL, message);
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
