namespace NLogging
{
    public interface IHandler
    {
        void Push(Record record);
        void Flush();
    }
}
