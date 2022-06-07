using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReTelegramBotSF
{
    internal class Bot: BackgroundService
    {
        private ITelegramBotClient _telegramClient;
        public Bot(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //  Обрабатываем нажатия на кнопки  из Telegram Bot API: https://core.telegram.org/bots/api#callbackquery
            if (update.Type == UpdateType.CallbackQuery)
            {
                await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Вы нажали кнопку", cancellationToken: cancellationToken);
                return;
            }

            // Обрабатываем входящие сообщения из Telegram Bot API: https://core.telegram.org/bots/api#message
            if (update.Type == UpdateType.Message)
            {
                string answer = "Вы отправили сообщение " + update.Message.Text + "\nКоличество символов: " + update.Message.Text.Length;
                await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, answer, cancellationToken: cancellationToken);
                return;
            }
        }
        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);
            Console.WriteLine("Ожидаем 10 секунд перед повторным подключением...");
            Thread.Sleep(10000);
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _telegramClient.StartReceiving(
                HandleUpdateAsync, 
                HandleErrorAsync, 
                new ReceiverOptions() { AllowedUpdates = { } }, 
                cancellationToken: stoppingToken);
            Console.WriteLine("Bot started...");
        }
    }
}
