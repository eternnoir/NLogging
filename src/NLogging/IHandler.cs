namespace NLogging
{
    /// <summary>
    /// Handler interface.
    /// </summary>
    public interface IHandler
    {
        void Push(Record record);
        void Flush();
    }
}
