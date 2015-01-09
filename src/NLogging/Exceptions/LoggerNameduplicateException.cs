namespace NLogging.Exceptions
{
    class LoggerNameduplicateException : NLoggingException
    {
        public string LoggerName { get; set; }

        public LoggerNameduplicateException(string msg, string loggerName)
            : base(msg)
        {
            this.LoggerName = loggerName;
        }
    }
}
