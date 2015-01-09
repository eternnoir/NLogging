using System;
namespace NLogging.Exceptions
{
    [Serializable]
    class NLoggingException : Exception
    {
        public NLoggingException(string msg)
            : base(msg)
        {
        }
    }
}
