using System;
using System.Collections.Generic;
using System.Text;

namespace Mod10
{
    internal class Task1_2
    {
        static ILogger Logger { get; set; }
        public static void Run()
        {
            Logger = new Logger();
            bool p = true;
            while (p)
            {
                try
                {
                    Console.WriteLine("Введите 2 числа, которые хотите спросить");
                    double a = Convert.ToInt32(Console.ReadLine());
                    double b = Convert.ToInt32(Console.ReadLine());
                    Calculator calculator = new Calculator(Logger);
                    Console.WriteLine(calculator.CalculateSum(a, b));
                    p = false;
                }
                catch (FormatException)
                {
                    Logger.Error("Слагаемое введено не верно");
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
    }
}
