namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    class ConsoleHandler : AbstractHandler
    {
        public override void Push(Record record)
        {
            string formatedMsg = this.formatter.FormatMessage(record);
            System.Console.Write(formatedMsg);
        }

        public override void Flush()
        {
        }
    }
}
