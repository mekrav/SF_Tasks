using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using ReTelegramBotSF.Controllers;

namespace ReTelegramBotSF
{
    internal class Bot: BackgroundService
    {
        private ITelegramBotClient _telegramClient;
        //Controllers
        private InlineKeyboardController _inlineKeyController;
        private TextMessageController _textMessageController;
        private VoiceMessageController _voiceMessageController;
        private DefaultMessageController _defaultMessageController;

        public Bot(
            ITelegramBotClient telegramClient, 
            InlineKeyboardController inlineKeyController, 
            TextMessageController textMessageController, 
            VoiceMessageController voiceMessageController, 
            DefaultMessageController defaultMessageController)
        {
            _telegramClient = telegramClient;
            _inlineKeyController = inlineKeyController;
            _textMessageController = textMessageController;
            _voiceMessageController = voiceMessageController;
            _defaultMessageController = defaultMessageController;
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
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //  Обрабатываем нажатия на кнопки  из Telegram Bot API: https://core.telegram.org/bots/api#callbackquery
            if (update.Type == UpdateType.CallbackQuery)
            {
                await _inlineKeyController.Handle(update.CallbackQuery, cancellationToken);
                return;
            }

            // Обрабатываем входящие сообщения из Telegram Bot API: https://core.telegram.org/bots/api#message
            if (update.Type == UpdateType.Message)
            {
                switch (update.Message!.Type) //Why? Why?
                {
                    case MessageType.Voice:
                        await _voiceMessageController.Handle(update.Message, cancellationToken);
                        break;
                    case MessageType.Text:
                        await _textMessageController.Handle(update.Message, cancellationToken);
                        break;
                    default:
                        await _defaultMessageController.Handle(update.Message, cancellationToken);
                        return;
                }
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


    }
}
