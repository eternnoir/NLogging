namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

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

        public string LoggerName
        {
            get
            {
                return this.loggerName;
            }
        }

        public LogLevel Level
        {
            get
            {
                return this.level;
            }
        }

        public StackTrace Stack
        {
            get
            {
                return this.stack;
            }
        }

        public string Message
        {
            get
            {
                return this.msg;
            }
        }

        public string FileName
        {
            get
            {
                return this.callerStackFrame.GetFileName();
            }
        }

        public string FunctionName
        {
            get
            {
                return this.func;
            }
        }


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

        public Exception Exception
        {
            get
            {
                return this.exception;
            }
        }

    }
}
