using System;
using System.Threading;
using BenchmarkDotNet.Running;

namespace Mod12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var users = User.ParseArgs(args);
            // Начало
            foreach(var user in users)
            {
                Console.WriteLine("Здравствуйте, " + user.Name);
                if (!user.IsPremium)
                {
                    ShowAds();
                }
            }
            //Конец
            */
            var summary = BenchmarkRunner.Run<Testing>();
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}
