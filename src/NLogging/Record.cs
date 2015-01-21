namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Logging Record.
    /// </summary>
    public class Record
    {
        private string loggerName;
        private LogLevel level;
        private StackTrace stack;
        private string msg;
        private string func;
        private StackFrame callerStackFrame;
        private Exception exception;

        public Record(string loggerName, LogLevel logLevel, StackTrace stacktrace, string msg, string func, StackFrame callerStackFrame,Exception e)
        {
            this.loggerName = loggerName;
            this.level = logLevel;
            this.stack = stacktrace;
            this.msg = msg;
            this.func = func;
            this.callerStackFrame = callerStackFrame;
            this.exception = e;
        }

        /// <summary>
        /// Which logger record.
        /// </summary>
        public string LoggerName
        {
            get
            {
                return this.loggerName;
            }
        }

        /// <summary>
        /// Record's log level.
        /// </summary>
        public LogLevel Level
        {
            get
            {
                return this.level;
            }
        }

        /// <summary>
        /// Record's stack trace.
        /// </summary>
        public StackTrace Stack
        {
            get
            {
                return this.stack;
            }
        }

        /// <summary>
        /// Log message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.msg;
            }
        }

        /// <summary>
        /// Logging file name.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.callerStackFrame.GetFileName();
            }
        }

        /// <summary>
        /// Which method logged.
        /// </summary>
        public string FunctionName
        {
            get
            {
                return this.func;
            }
        }

        /// <summary>
        /// Line number call log.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.callerStackFrame.GetFileLineNumber();
            }
        }

        public StackFrame CallerStackFrame
        {
            get
            {
                return this.callerStackFrame;
            }
        }
        
        /// <summary>
        /// Log exception.
        /// </summary>
        public Exception Exception
        {
            get
            {
                return this.exception;
            }
        }

    }
}
