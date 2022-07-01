using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mod18
{
    internal class CommandDownload: ICommand
    {
        Downloader _downloader;

        public CommandDownload(Downloader downloader)
        {
            _downloader = downloader;
        }

        public async Task Run()
        {
            await _downloader.Run();
        }
    }
}
