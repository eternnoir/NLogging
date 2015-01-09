namespace NLogging.Exceptions
{
    public class LoggerNameDuplicateException : NLoggingException
    {
        public string LoggerName { get; set; }

        public LoggerNameDuplicateException(string msg, string loggerName)
            : base(msg)
        {
            this.LoggerName = loggerName;
        }
    }
}
