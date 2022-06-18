using System;
using System.Collections.Generic;

namespace Mod13
{
    internal class Program
    {
        static void Main()
        {
            /* //Part1
            string path = "D:\\SkillFactory\\cdev_Text.txt";
            Console.WriteLine(Part1.WordCountTxt(path));
            */
            /*//Part3
            string data = "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";
            var characters = data.ToCharArray();

            var symbols = new HashSet<char>();

            foreach (var symbol in characters)
                symbols.Add(symbol);

            Console.WriteLine(symbols.Count);
            */

            //Залание 2. Считает Top N слов, передать N и путь до файла.
            int position = 20;
            string path = "D:\\bup.txt";
            FinalTask2.Run(position, path);            
        }
    }
}
