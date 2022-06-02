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
        // Так не надо
        static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Нажмите любую кнопку для остановки");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine("Получено сообщение в чате: " + e.Message.Chat.Id + ".");

                await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            }
        }
    }
}
