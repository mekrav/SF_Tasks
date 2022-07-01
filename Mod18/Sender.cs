using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mod18
{
    internal class Sender
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task Run()
        {
            await _command.Run();
        }
    }
}
