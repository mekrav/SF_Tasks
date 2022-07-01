using System;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

//https://www.youtube.com/watch?v=djV11Xbc914 
namespace Mod18
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            await Run();
        }

        async static Task Run()
        {
            var videoUrl = "https://www.youtube.com/watch?v=djV11Xbc914";
            string outputFilePath = "D:\\SkillFactory\\videos\\done.mp4";

            var senderInfo = new Sender();
            var descriptionShower = new DescriptionShower(videoUrl);
            var commandShowInformation = new CommandShowInformation(descriptionShower);

            senderInfo.SetCommand(commandShowInformation);
            await senderInfo.Run();

            var senderDownload = new Sender();
            var downloader = new Downloader(videoUrl, outputFilePath);
            var commandDownload = new CommandDownload(downloader);

            senderDownload.SetCommand(commandDownload);
            await senderDownload.Run();
        }
    }
}
