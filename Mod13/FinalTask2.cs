using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Mod13
{
    internal static class FinalTask2
    {
        public static void Run(int position, string path)
        {
            var words = FinalTask2.WordsExtracter(path);
            var wordCount = FinalTask2.GetContent(words);
            var topWords = FinalTask2.Top(wordCount, position);
            foreach (var word in topWords)
            {
                Console.WriteLine(word);
            }
        }
        static Dictionary<string,int> GetContent(string[] words)
        {
            Dictionary<string,int> wordsCount = new Dictionary<string,int>();
            foreach (string word in words)
            {
                string currentWord = word.ToLower();
                if (wordsCount.ContainsKey(currentWord))
                {
                    wordsCount[currentWord]++;
                }
                else
                {
                    wordsCount.Add(currentWord, 1);
                }
            }
            return wordsCount;
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
                return words;
            }
            return null;
        }
        static LinkedList<(string, int)> Top(Dictionary<string,int> dataSet, int position)
        {
            if (dataSet == null)
                return null;
            LinkedList<(string, int)> top = new LinkedList<(string, int)>();
            for (int i = 0; i < position; i++)
            {
                top.AddFirst((null, 0));
            }
            int minTopWordCount = 0;
            foreach(KeyValuePair<string,int> pair in dataSet)
            {
                if (pair.Value > minTopWordCount)
                {
                    RearengeTop(top, (pair.Key, pair.Value));
                    minTopWordCount = top.Last.Value.Item2;
                }
            }
            return top;
        }

        static void RearengeTop(LinkedList<(string,int)> topList, (string,int) pair)
        {
            bool inserted = false;
            var currentNode = topList.First;

            while(!inserted && currentNode != null)
            {
                if(currentNode.Value.Item2 <= pair.Item2)
                {
                    topList.AddBefore(currentNode, pair);
                    inserted = true;
                }
                currentNode = currentNode.Next;
            }
            topList.RemoveLast();
        }

        public static void Test()
        {
            string text = "A,b,ап, уву. ввпбзбаа- абщщб, кщщпьа.";
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] delimeters = { ' ', '\n', '\r' };
            string[] words = noPunctuationText.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                Console.WriteLine(noPunctuationText);
            }
        }
    }
}
