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

            // Не 8,3,1, но то как я его первоначально поняла) ShowMe();

            // AddLounchData();

            /*
            WriterBin();
            ReadBin();
            */

            // Метод рекурсивный, поэтому считаю что его нужно оборачивать в try{}catch{} 
            // Сигнатура метода: DeleteOldFiles(string FolderPath, int MinNotUsed)
            try
            {
                Task1.DeleteOldFiles("C:\\Users\\mibot.ru\\Desktop\\TestFolde", 30);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
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
            catch (Exception ex)
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

        //Да здравствуют квайны)
        static void ShowMe()
        {
            string s = "static void ShowMe() {{ string s={0}{1}{0}; System.Console.Write(s,(char)34,s); }}";
            System.Console.Write(s, (char)34, s);
        }

        static void AddLounchData()
        {
            FileInfo CurrentFile = new FileInfo(@"D:\SkillFactory\Tasks\ConsoleTasks\Mod8\M8Program.cs");
            DateTime LocalDate = DateTime.Now;
            var culture = new CultureInfo("ru-RU");
            using (StreamWriter sw = CurrentFile.AppendText())
            {
                sw.WriteLine(@"//" + LocalDate.ToString(culture));
            }
        }

        static void ReadBin()
        {
            string StringValue = "?";
            string FileName = @"C:\Users\mibot.ru\Desktop\BinaryFile.bin";
            if (File.Exists(FileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    StringValue = reader.ReadString();
                }
            }
            Console.WriteLine(StringValue);
        }

        public static void WriterBin()
        {
            string FileName = @"C:\Users\mibot.ru\Desktop\BinaryFile.bin";
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open)))
                writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");

        }
    }
}
//20.05.2022 23:19:01