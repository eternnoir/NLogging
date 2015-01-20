namespace NLogging.Exceptions
{
    /// <summary>
    /// Throw this exception when add same name logger.
    /// </summary>
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
