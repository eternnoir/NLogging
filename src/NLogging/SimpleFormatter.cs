namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Basic Fomatter.
    /// </summary>
    public class SimpleFormatter : IFormatter
    {
        public string FormatMessage(Record record)
        {
            string formatedMsg = string.Format("===============================\n[{0}] [{1}]:\n==============================={2}",DateTime.Now.ToString(),record.Message);
            if (record.Exception != null)
            {
                formatedMsg += "\n[Exception]===============================" + record.Exception.ToString();
            }

            return record.Message;
        }
    }
}
