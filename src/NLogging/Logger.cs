namespace NLogging
{
    using System;
    using System.Collections.Generic;
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
    }
}
