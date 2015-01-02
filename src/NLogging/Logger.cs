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

        public string LoggerName 
        {
            get
            {
                return this.loggerName;
            }
        }
        public Logger(string loggerName)
        {
            this.loggerName = loggerName;
        }
    }
}
