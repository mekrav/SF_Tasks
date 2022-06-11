using System.IO;
using FFMpegCore;
using ReTelegramBotSF.Extensions;

namespace ReTelegramBotSF.Utilities
{
    internal static class AudioConverter
    {
        public static void TryConvert(string inputFile, string outputFile)
        {
            // Задаём путь, где лежит вспомогательная программа - конвертер
            GlobalFFOptions.Configure(options => options.BinaryFolder = Path.Combine(DirectoryExtensions.GetSolutionRoot(), "ffmpeg-win64", "bin"));

            // Вызываем Ffmpeg, передав требуемые аргументы.
            FFMpegArguments
              .FromFileInput(inputFile)
              .OutputToFile(outputFile, true, options => options
              .WithFastStart())
              .ProcessSynchronously();
        }

    }
}
