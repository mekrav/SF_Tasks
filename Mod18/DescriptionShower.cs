using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Mod18
{
    internal class DescriptionShower
    {
        //Что бы не задавать параметры через интерфейс комманды
        string videoUrl;
        public DescriptionShower(string videoUrl)
        {
            this.videoUrl = videoUrl;
        }

        public async Task Operation()
        {
            var YouTubeClient = new YoutubeClient();

            var video = await YouTubeClient.Videos.GetAsync(videoUrl);
            Console.WriteLine("___________________");
            Console.WriteLine(video.Title);
            Console.WriteLine(video.Author.ChannelTitle);
            Console.WriteLine(video.Duration);
            Console.WriteLine(video.Description);
        }
    }
}
