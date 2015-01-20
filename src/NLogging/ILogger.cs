namespace NLogging
{
    using System;
    /// <summary>
    /// Logger interface.
    /// </summary>
    public interface ILogger
    {
        string Name
        {
            get;
        }
        void SetLevel(LogLevel level);
        void AddHandler(IHandler handler);
        void Critical(string message);
        void Critical(Exception e, string message);
        void Error(string message);
        void Error(Exception e, string message);
        void Warning(string message);
        void Warning(Exception e, string message);
        void Info(string message);
        void Info(Exception e, string message);
        void Debug(string message);
        void Debug(Exception e, string message);
        void WriteLog(LogLevel level, string message);
        void WriteLog(LogLevel level, string message,Exception e);
    }
}
