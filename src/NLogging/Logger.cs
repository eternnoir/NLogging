﻿namespace NLogging
{
    using NLogging.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A thread safe basic logger.
    /// </summary>
    public class Logger : ILogger
    {
        private string loggerName;
        private LogLevel logLevel;
        private List<IHandler> handlerList;
        private object syncObj = new object();

        /// <summary>
        /// Logger constractor.
        /// Default log level is NOSET.
        /// </summary>
        /// <param name="loggerName"></param>
        public Logger(string loggerName)
        {
            this.Init(loggerName, LogLevel.NOTSET);
        }

        public Logger(string loggerName, LogLevel logLevel)
        {
            this.Init(loggerName, logLevel);
        }

        /// <summary>
        /// Logger Name property getter.
        /// </summary>
        public string Name
        {
            get
            {
                return this.loggerName;
            }
        }

        /// <summary>
        /// Set log level to this logger.
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(LogLevel level)
        {
            lock (this.syncObj)
            {
                this.logLevel = level;
            }
        }

        /// <summary>
        /// Log Critical.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Critical(string message)
        {
            if (!this.CanLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.PushLog(LogLevel.CRITICAL, message, null);
        }

        /// <summary>
        ///Log Critical. 
        /// </summary>
        /// <param name="format">String Format</param>
        /// <param name="args">args</param>
        public void CriticalFormat(string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.PushLog(LogLevel.CRITICAL, string.Format(format, args), null);
        }

        /// <summary>
        /// Log Critical with exception.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="message">Log message</param>
        public void Critical(Exception e, string message)
        {
            if (!this.CanLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.PushLog(LogLevel.CRITICAL, message, e);
        }

        public void CriticalFormat(Exception e, string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.CRITICAL))
            {
                return;
            }
            this.PushLog(LogLevel.CRITICAL, string.Format(format, args), e); ;
        }

        /// <summary>
        /// Log Error.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Error(string message)
        {
            if (!this.CanLog(LogLevel.ERROR))
            {
                return;
            }
            this.PushLog(LogLevel.ERROR, message, null);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.ERROR))
            {
                return;
            }
            this.PushLog(LogLevel.ERROR, string.Format(format, args), null); ;
        }

        /// <summary>
        /// Log Error with exception.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="message">Log message</param>
        public void Error(Exception e, string message)
        {
            if (!this.CanLog(LogLevel.ERROR))
            {
                return;
            }
            this.PushLog(LogLevel.ERROR, message, e);
        }


        public void ErrorFormat(Exception e, string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.ERROR))
            {
                return;
            }
            this.PushLog(LogLevel.ERROR, string.Format(format, args), e); ;
        }

        /// <summary>
        /// Log Warning.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Warning(string message)
        {
            if (!this.CanLog(LogLevel.WARNING))
            {
                return;
            }
            this.PushLog(LogLevel.WARNING, message, null);
        }


        public void WarningFormat(string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.WARNING))
            {
                return;
            }
            this.PushLog(LogLevel.WARNING, string.Format(format, args), null); ;
        }

        /// <summary>
        /// Log Warning with exception.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="message">Log message</param>
        public void Warning(Exception e, string message)
        {
            if (!this.CanLog(LogLevel.WARNING))
            {
                return;
            }
            this.PushLog(LogLevel.WARNING, message, e);
        }


        public void WarningFormat(Exception e, string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.WARNING))
            {
                return;
            }
            this.PushLog(LogLevel.WARNING, string.Format(format, args), e); ;
        }

        /// <summary>
        /// Log Info.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Info(string message)
        {
            if (!this.CanLog(LogLevel.INFO))
            {
                return;
            }
            this.PushLog(LogLevel.INFO, message, null);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.INFO))
            {
                return;
            }
            this.PushLog(LogLevel.INFO, string.Format(format, args), null); ;
        }

        /// <summary>
        /// Log Info with exception.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="message">Log message</param>
        public void Info(Exception e, string message)
        {
            if (!this.CanLog(LogLevel.INFO))
            {
                return;
            }
            this.PushLog(LogLevel.INFO, message, e);
        }



        public void InfoFormat(Exception e, string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.INFO))
            {
                return;
            }
            this.PushLog(LogLevel.INFO, string.Format(format, args), e); ;
        }


        /// <summary>
        /// Log Debug.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Debug(string message)
        {
            if (!this.CanLog(LogLevel.DEBUG))
            {
                return;
            }
            this.PushLog(LogLevel.DEBUG, message, null);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.DEBUG))
            {
                return;
            }
            this.PushLog(LogLevel.DEBUG, string.Format(format, args), null); ;
        }

        /// <summary>
        /// Log Debug with exception.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="message">Log message</param>
        public void Debug(Exception e, string message)
        {
            if (!this.CanLog(LogLevel.DEBUG))
            {
                return;
            }
            this.PushLog(LogLevel.DEBUG, message, e);
        }





        public void DebugFormat(Exception e, string format, params object[] args)
        {
            if (!this.CanLog(LogLevel.DEBUG))
            {
                return;
            }
            this.PushLog(LogLevel.DEBUG, string.Format(format, args), e); ;
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

        /// <summary>
        /// Write log whith loglevel and message.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void WriteLog(LogLevel level, string message)
        {
            this.WriteLog(level, message, null);
        }

        public void WriteLog(LogLevel level, string message, Exception e)
        {
            this.PushLog(level, message, e);
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

        private void PushLog(LogLevel level, string message, Exception e)
        {
            if (message == null)
            {
                Logging.WriteDebugMessage("Message can not be null");
            }
            StackTrace stack = new System.Diagnostics.StackTrace(true);
            // Get caller method name. 2 level upper from stack frames.
            StackFrame callerStackFrame = stack.GetFrame(2);
            string functionName = callerStackFrame.GetMethod().Name;
            Record record = new Record(this.loggerName, level, stack, message, functionName, callerStackFrame, e);
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
