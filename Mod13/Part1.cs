using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Mod13
{
    internal static class Part1
    {
        public static int WordCountTxt(string path)
        {
            string data;
            if (File.Exists(path))
            {
                data = File.ReadAllText(path);
                char[] delimeters = { ' ', '\n', '\r' };
                string[] words = data.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                return words.Length;
            }

            return 0;
        }
    }
}
