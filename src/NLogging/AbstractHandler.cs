namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class AbstractHandler : IHandler
    {
        protected IFormatter formatter;

        protected AbstractHandler()
        {
            this.formatter = new SimpleFormatter();
        }

        public abstract void Push(Record record);
        public abstract void Flush();

        public void SetFormatter(IFormatter formatter)
        {
            this.formatter = formatter;
        }
    }
}
