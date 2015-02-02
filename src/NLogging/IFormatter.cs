namespace NLogging
{
    /// <summary>
    /// Formatter interface.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Format record to message.
        /// </summary>
        /// <param name="record"></param>
        /// <returns>Formated message</returns>
        string FormatMessage(Record record);
    }
}
