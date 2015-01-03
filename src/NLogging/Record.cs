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

        public string FunctionName
        {
            get
            {
                return this.func;
            }
        }

        public Record(string loggerName, LogLevel logLevel, StackTrace stacktrace, string msg, string func)
        {
            this.loggerName = loggerName;
            this.level = logLevel;
            this.stack = stacktrace;
            this.msg = msg;
            this.func = func;
        }

    }
}
