using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal static class StringExtensions
    {
        public static bool IsPhoneNumber(this string source)
        {
            return source.Length == 10;
        }
    }
}
