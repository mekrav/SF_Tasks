using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using FinTelegramBotSF.Services;
using FinTelegramBotSF.Utilities;

namespace FinTelegramBotSF.Controllers
{
    internal class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;
        public TextMessageController(ITelegramBotClient telegramClient, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                    InlineKeyboardButton.WithCallbackData($"Symbol count", $"count"),
                    InlineKeyboardButton.WithCallbackData($"Sum numbers", $"sum")
                });
                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Test bot.</b> {Environment.NewLine}" +
                          $"{Environment.NewLine}Считает символы и суммирует числа.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
                default:
                    var workMode = _memoryStorage.GetSession(message.Chat.Id).WorkMode;
                    string reply;
                    switch (workMode)
                    {
                        case "count":
                            reply = Length.Count(message.Text).ToString();
                            break;
                        case "sum":
                            reply = Sum.Count(message.Text).ToString();
                            break;
                        default:
                            reply = "Что-то пошло не так";
                            break;
                    }
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение {reply}", cancellationToken: ct);
                    break;
            }
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
        }
    }
}