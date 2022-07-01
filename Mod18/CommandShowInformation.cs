using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Mod18
{
    internal class CommandShowInformation : ICommand
    {
        DescriptionShower _descriptionShower;

        public CommandShowInformation(DescriptionShower descriptionShower)
        {
            _descriptionShower = descriptionShower;
        }

        public async Task Run()
        {
            await _descriptionShower.Operation();
        }
    }
}
