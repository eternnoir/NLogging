namespace NLogging
{
    /// <summary>
    /// Formatter interface.
    /// </summary>
    public interface IFormatter
    {
        string FormatMessage(Record record);
    }
}
