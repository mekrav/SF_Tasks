using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using FinTelegramBotSF.Controllers;
using FinTelegramBotSF.Services;
using FinTelegramBotSF.Config;

namespace FinTelegramBotSF
{
    internal class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервис запущен");
            await host.RunAsync();
            Console.WriteLine("Service stopped");
        }
        static void ConfigureServices(IServiceCollection services)
        {
            BotCredentials botCredentials = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(botCredentials.BotToken));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }

        static BotCredentials BuildAppSettings()
        {
            return new BotCredentials()
            {
                BotToken = "TOKEN"
            };
        }
    }
}
