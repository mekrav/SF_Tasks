using System;
using System.IO;
using System.Text;

namespace ConsoleTasks.Mod8
{
    internal static class M8Program
    {
        static public void M8Main()
        {
            /* 8.2.1 - 8.2.3 
            CountCatalogs();
            AddFolder("D:\\SFtestFolder");
            CountCatalogs();
            DeleteFolder("D:\\SFtestFolder");
            CountCatalogs();
            */

            /* 8.2.4 - не работает метод MoveToTrash
            AddFolder("C:\\Users\\mibot.ru\\Desktop\\SFtestFolder");
            Console.ReadKey();
            MoveToTrash("C:\\Users\\mibot.ru\\Desktop\\SFtestFolder");
            */
        }

        static void GetInfo()
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
        }

        static void GetCatalogs()
        {
            string dirName = @"D:\\"; // Прописываем путь к директории Windows
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }

        static void CountCatalogs()
        {
            string dirName = @"D:\\"; // Прописываем путь к директории Windows
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                Console.WriteLine("Папки: " + dirs.Length);

                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога
                Console.WriteLine("Файлы: " + files.Length);

                Console.WriteLine();
            }
        }

        static void AddFolder(string Path)
        {
            try
            {
                DirectoryInfo NewDir = new DirectoryInfo(@Path);
                if (!NewDir.Exists)
                    NewDir.Create();
                else
                    throw new NullReferenceException("Такая папка уже есть");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteFolder(string Path)
        {
            try
            {
                DirectoryInfo NewDir = new DirectoryInfo(@Path);
                if (NewDir.Exists)
                    NewDir.Delete(true);
                else
                    throw new Exception("Такой папка нет");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void MoveToTrash(string Path) //Не работает, не корректный путь к корзине (спойлер, обычный Delete сваливает в корзину)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@Path);
                string Trash = "C:\\$Recycle.Bin";
                if (dir.Exists && !Directory.Exists(Trash))
                    dir.MoveTo(Trash);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

