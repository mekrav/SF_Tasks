using System;
using System.IO;
using System.Text;
using System.Globalization;

namespace Mod8
{
    internal static class Program
    {
        static public void Main(string[] args)
        {
            // Запуск учебных заданий 
            // Disclaimer: перед запуском нужно раскомментировать необходимые пункты
            // StadyTasks.Run();

            // Запуск первого задания
            // Сигнатура метода: Run(string FolderPath, int MinNotUsed)
            // Task1.Run("C:\\path", 30);

            // Запуск второго задания
            // Сигнатура метода: Run(string FolderPath)
            // Task2.Run(@"D:\\path");

            // Запуск третьего задания
            // Сигнатура метода: Run(string FolderPath, int MinNotUsed)
            // Task3.Run("C:\\path", 3);

            // Запуск четвёртого задания
            Task4.Run();
        }
    }
}