using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotSF
{
    internal class Program
    {
        static void Main()
        {
            BotWorker worker = new BotWorker();
            worker.Initialize();
            worker.Stat();

            Console.WriteLine("Нажмите любую кнопку для остановки");

            string command;
            do
            {
                command = Console.ReadLine();

            } while (command != "stop");

            worker.Stop();
        }

        
    }
}
