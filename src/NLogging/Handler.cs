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
