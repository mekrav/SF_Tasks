using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using ReTelegramBotSF.Controllers;
using ReTelegramBotSF.Services;
using ReTelegramBotSF.Config;

namespace ReTelegramBotSF.Services
{
    internal interface IFileHandler
    {
        Task Download(string fileId, CancellationToken ct);
        string Process(string param); 
    }
}
