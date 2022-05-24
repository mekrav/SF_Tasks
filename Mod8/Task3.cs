using System;
using System.Collections.Generic;
using System.Text;

namespace Mod8
{
    internal static class Task3
    {
        public static void Run(string FolderPath, int MinNotUsed)
        {
            //Не использую try{}catch{}, так как в медодах вида Run уже обрабатываются ошибки
            Task2.Run(FolderPath);
            Task1.Run(FolderPath, MinNotUsed);
            Task2.Run(FolderPath);
        }
    }
}
