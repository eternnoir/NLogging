namespace NLogging
{
    public interface ILogger
    {
        string Name
        {
            get;
        }
        void SetLevel(LogLevel level);
        void AddHandler(IHandler handler);
        void Critical(string message);
        void Error(string message);
        void Warning(string message);
        void Info(string message);
        void Debug(string message);
        void WriteLog(LogLevel level, string message);
    }
}
