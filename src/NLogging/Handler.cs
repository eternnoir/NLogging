namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Handler : IHandler
    {
        private IFormatter formatter;


        protected Handler()
        {
        }

        abstract public void push(Record record);
        abstract public void flush();
        abstract public void SetFormatter(IFormatter formatter);
    }
}
