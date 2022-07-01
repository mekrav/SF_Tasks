using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Mod18
{
    internal interface ICommand
    {
        //В данном случае нам нужен только запуск
        public Task Run();
    }
}
