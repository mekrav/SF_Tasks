using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mod8
{
    internal static class Task1
    {
        public static void Run (string FolderPath, int MinNotUsed)
        {
            // Метод рекурсивный, поэтому считаю что его нужно оборачивать в try{}catch{} 
            // Сигнатура метода: DeleteOldFiles(string FolderPath, int MinNotUsed)
            try
            {
                DeleteOldFiles(FolderPath, MinNotUsed);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
        }

        static void DeleteOldFiles(string FolderPath, int MinNotUsed)
        {
            if (Directory.Exists(FolderPath))
            {
                TimeSpan CalmInterval = TimeSpan.FromMinutes(MinNotUsed);
                string[] dirs = Directory.GetDirectories(FolderPath);
                foreach (string d in dirs)
                {
                    var dir = new DirectoryInfo(d);
                    if (DateTime.Now - dir.LastAccessTime >= CalmInterval)
                    {
                        dir.Delete(true); // Если папка не использовалась, то все файлы в ней соответственно тоже не использовались
                        return; 
                    }

                    try //Здесь вряд ли будет ошибка, но может быть проблема с доступом
                    {
                        DeleteOldFiles(d, MinNotUsed);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e}");
                    }
                }

                Console.WriteLine();

                string[] files = Directory.GetFiles(FolderPath);
                foreach (string f in files)
                {
                    var fi = new FileInfo(f);
                    if (DateTime.Now - fi.LastAccessTime >= CalmInterval)
                    {
                        try //Проблемы с доступом
                        {
                            fi.Delete();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine($"Ошибка: {e}" + "\n Проблема с доступом к файлу");
                        }
                    }
                }   
            }
            else throw new Exception($"Не корректный путь, папки {FolderPath} не найдено или нет доступа к данным или папкам.");
        }
    }
}
