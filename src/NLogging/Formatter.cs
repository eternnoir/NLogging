﻿namespace NLogging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Formatter : IFormatter
    {
        public string FormatMessage(Record record)
        {
            return record.Message;
        }
    }
}