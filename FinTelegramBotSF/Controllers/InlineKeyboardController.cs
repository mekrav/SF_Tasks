using System;
using System.Threading;
using System.Threading.Tasks;

using Telegram.Bot;

using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using FinTelegramBotSF.Services;

namespace FinTelegramBotSF.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;

        public InlineKeyboardController(ITelegramBotClient telegramClient, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery == null)
                return;
            _memoryStorage.GetSession(callbackQuery.From.Id).WorkMode = callbackQuery.Data;
            //Generate message
            string workMode = callbackQuery.Data switch
            {
                "count" => "Подсчёт символов в строке",
                "sum" => "Подсчёт суммы чисел",
                _ => String.Empty
            };
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"<b>Выбран режим - {workMode}.{Environment.NewLine}</b>" +
                  $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
        }
    }
}
