namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Handler : IHandler
    {
        private IFormatter formatter;
        private LogLevel logLevel;

        protected Handler()
        {
            this.formatter = new Formatter();
            this.logLevel = LogLevel.NOTSET;
        }

        abstract public void push(Record record);
        abstract public void flush();
        public void SetFormatter(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void SetLogLevel(LogLevel level)
        {
            this.logLevel = level;
        }

    }
}
