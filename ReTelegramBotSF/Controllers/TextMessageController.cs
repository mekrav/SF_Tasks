using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReTelegramBotSF.Controllers
{
    internal class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public TextMessageController(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }
    }
}
