using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLogging
{
    public interface ILogger
    {
        string Name
        {
            get;
        }

        void AddHandler(IHandler handler);
        void Critical(string message);
        void Warning(string message);
        void Info(string message);
        void Debug(string message);
        void WriteLog(LogLevel level, string message);
    }
}
