using System;
using System.Collections.Generic;
using System.Text;

namespace Mod9
{
    internal class Task1_Ex: Exception
    {
        public Task1_Ex() { }
        public Task1_Ex(string Message) : base(Message) { }
    }
}
