using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLogging
{
    public interface IFormatter
    {
        string FormatMessage(Record record);
    }
}
