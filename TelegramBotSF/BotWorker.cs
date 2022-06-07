using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace TelegramBotSF
{
    internal class BotWorker
    {
        ITelegramBotClient botClient;
        BotMessageLogic logic;

        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);

        }
        public void Stat()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                Console.WriteLine("Получено сообщение в чате: " + e.Message.Chat.Id + ".");
                await logic.Response(e);
            }
        }

    }
}
