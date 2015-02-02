namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Abstract Handler implement IHandler.
    /// It has one formatter to format record imformation.
    /// </summary>
    public abstract class AbstractHandler : IHandler
    {
        /// <summary>
        /// Formatter member.
        /// </summary>
        protected IFormatter formatter;

        /// <summary>
        /// AbstractHandler constractor. It default ues SimpleFormatter.
        /// </summary>
        protected AbstractHandler()
        {
            this.formatter = new SimpleFormatter();
        }

        /// <summary>
        /// Push log record to handler.
        /// </summary>
        /// <param name="record"></param>
        public abstract void Push(Record record);

        /// <summary>
        /// The method let handler to flush.
        /// </summary>
        public abstract void Flush();
        
        /// <summary>
        /// Formatter srtter.
        /// </summary>
        /// <param name="formatter"></param>
        public void SetFormatter(IFormatter formatter)
        {
            this.formatter = formatter;
        }
    }
}
