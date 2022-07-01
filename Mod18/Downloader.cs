using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Mod18
{
    internal class Downloader
    {
        string videoUrl;
        string outputFilePath;
        public Downloader(string videoUrl, string outputFilePath)
        {
            this.videoUrl = videoUrl;
            this.outputFilePath = outputFilePath;
        }

        public async Task Run()
        {
            var YouTubeClient = new YoutubeClient();

            Console.WriteLine("Download in progress...");
            await YouTubeClient.Videos.DownloadAsync(videoUrl, outputFilePath, o => o
                .SetContainer("webm") // override format
                .SetPreset(ConversionPreset.UltraFast) // change preset
                .SetFFmpegPath("D:\\SkillFactory\\videos\\ffmpeg.exe") // custom FFmpeg location
            );
            Console.WriteLine("Video download complited.");
        }
    }
}
