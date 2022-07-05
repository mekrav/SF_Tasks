using System;
using System.Collections.Generic;
using System.Text;

namespace Mod19.PLL.Helpers
{
    internal class AlertMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
