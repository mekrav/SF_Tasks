using System;
using System.Collections.Generic;
using System.Text;

namespace Mod10
{
    internal interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
}
