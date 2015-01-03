using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLogging
{
    public interface IHandler
    {
        void push(Record record);
        void flush();
        void SetFormatter(IFormatter formatter);
    }
}
