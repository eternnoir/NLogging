using System;
namespace NLogging.Exceptions
{
    /// <summary>
    /// NLogging Base Exception.
    /// </summary>
    [Serializable]
    public class NLoggingException : Exception
    {
        public NLoggingException(string msg)
            : base(msg)
        {
        }
    }
}
