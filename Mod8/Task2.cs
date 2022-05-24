using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mod8
{
    internal class Task2
    {
        public static void Run(string FolderPath)
        {
            try
            {
                Console.WriteLine(FolderSize(FolderPath));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
        }

        static long FolderSize(string FolderPath)
        {
            long result = 0;
            if (Directory.Exists(FolderPath))
            {
                string[] dirs = Directory.GetDirectories(FolderPath);
                foreach (string d in dirs)
                {
                    var dir = new DirectoryInfo(d);
                    try //Здесь вряд ли будет ошибка, но может быть проблема с доступом
                    {
                        result += FolderSize(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e}");
                    }
                }
                string[] files = Directory.GetFiles(FolderPath);
                foreach (string f in files)
                {
                    var fi = new FileInfo(f);
                    try //Проблемы с доступом
                    {
                        result += fi.Length;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e}" + "\n Проблема с доступом к файлу");
                    }
                }
                return result;
            }
            else throw new Exception($"Не корректный путь, папки {FolderPath} не найдено или нет доступа к данным или папкам.");
        }
    }
}
