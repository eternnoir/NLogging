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
        /// <summary>
        /// Which logger make this record.
        /// </summary>
        private string loggerName;
        /// <summary>
        /// Log level
        /// </summary>
        private LogLevel level;
        /// <summary>
        /// Log call stack.
        /// </summary>
        private StackTrace stack;
        /// <summary>
        /// message.
        /// </summary>
        private string msg;
        /// <summary>
        /// Which function call logger.
        /// </summary>
        private string func;
        /// <summary>
        /// The Stack frame which function call logger.
        /// </summary>
        private StackFrame callerStackFrame;
        /// <summary>
        /// Exception. It will be null if not exception.
        /// </summary>
        private Exception exception;

        public Record(string loggerName, LogLevel logLevel, StackTrace stacktrace,
            string msg, string func, StackFrame callerStackFrame,Exception e)
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

        /// <summary>
        /// The stackframe which call logger.
        /// </summary>
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
