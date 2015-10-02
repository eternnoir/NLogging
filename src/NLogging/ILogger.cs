namespace NLogging
{
    using System;
    /// <summary>
    /// Logger interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Name getter.
        /// </summary>
        string Name
        {
            get;
        }

        void SetLevel(LogLevel level);
        void AddHandler(IHandler handler);
        void Critical(string message);
        void CriticalFormat(string format, params object[] args);
        void Critical(Exception e, string message);
        void CriticalFormat(Exception e, string format, params object[] args);
        void Error(string message);
        void ErrorFormat(string format, params object[] args);
        void Error(Exception e, string message);
        void ErrorFormat(Exception e, string format, params object[] args);
        void Warning(string message);
        void WarningFormat(string format, params object[] args);
        void Warning(Exception e, string message);
        void WarningFormat(Exception e, string format, params object[] args);
        void Info(string message);
        void InfoFormat(string format, params object[] args);
        void Info(Exception e, string message);
        void InfoFormat(Exception e, string format, params object[] args);
        void Debug(string message);
        void DebugFormat(string format, params object[] args);
        void Debug(Exception e, string message);
        void DebugFormat(Exception e, string format, params object[] args);
        void WriteLog(LogLevel level, string message);
        void WriteLog(LogLevel level, string message,Exception e);
    }
}
