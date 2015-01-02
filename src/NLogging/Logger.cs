namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Logger
    {
        private string loggerName;
        private LogLevel logLevel;

        public string LoggerName 
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
            this.loggerName = loggerName;
            this.logLevel = LogLevel.NOTSET;
        }

        public Logger(string loggerName, LogLevel logLevel)
        {
            this.loggerName = loggerName;
            this.logLevel = logLevel;
        }
    }
}
