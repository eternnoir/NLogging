namespace NLogging
{
    public interface IFormatter
    {
        string FormatMessage(Record record);
    }
}
