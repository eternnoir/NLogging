using System;
namespace NLogging.Exceptions
{
    [Serializable]
    public class NLoggingException : Exception
    {
        public NLoggingException(string msg)
            : base(msg)
        {
        }
    }
}
