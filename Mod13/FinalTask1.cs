using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Mod13
{
    internal class FinalTask1
    {
        public static void Run(string path)
        {
            var words = WordsExtracter(path);

            List<string> wordList = new List<string>(words);
            LinkedList<string> wordLinkedList = new LinkedList<string>(words);

            //в каждом методе находим элемент "обломов" и вставляем после него новый
            //считаем среднее за 100 запусков
            long allListTicks = 0;
            long allLinkedListTicks = 0;
            for (int i = 0; i < 100; i++)
            {
                allListTicks += InsertTimingList(wordList);
                allLinkedListTicks += InsertTimingLinkedList(wordLinkedList);
            }
            double avgListTicks = allListTicks / 100;
            double avgLinkedListTicks = allLinkedListTicks / 100;
            Console.WriteLine($"List: {avgListTicks}\nLinkedList: {avgLinkedListTicks}");
            //Мы не получаем исчерпывающую информацию о времени вставки элементов
            //Но мы понимаем, что вставка элементов в LinkedList проискодит в десятки раз быстрее, чем         }
        }
        static string[] WordsExtracter(string path)
        {
            string text;
            if (File.Exists(path))
            {
                text = File.ReadAllText(path);
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                char[] delimeters = { ' ', '\n', '\r' };
                string[] words = noPunctuationText.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                return GetDifferentWords(words);
            }
            return null;
        }
        static string[] GetDifferentWords(string[] words)
        {
            HashSet<string> wordsDifferent = new HashSet<string>();
            foreach (string word in words)
                wordsDifferent.Add(word.ToLower());
            string[] wordsDif = new string[wordsDifferent.Count];
            wordsDifferent.CopyTo(wordsDif);
            return wordsDif;
        }
        static long InsertTimingList(List<string> words)
        {
            Stopwatch watch = new Stopwatch();
            //Поиск элемента учитываться не будет
            int pos = words.IndexOf("обломов");
            watch.Start();
            words.Insert(pos, "вабба лабба даб даб"); //Обломову отчасти подходит
            watch.Stop();
            return watch.ElapsedTicks;
        }
        static long InsertTimingLinkedList(LinkedList<string> words)
        {
            Stopwatch watch = new Stopwatch();
            var pos = words.Find("обломов");
            //Поиск элемента учитываться не будет
            watch.Start();
            words.AddAfter(pos, "вабба лабба даб даб");
            watch.Stop();
            return watch.ElapsedTicks;
        }
    }
}
