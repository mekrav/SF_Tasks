using System;
using System.Collections.Generic;
using System.Text;

namespace Mod10
{
    internal class Task1
    {
        public static void Run()
        {
            bool p = true;
            while (p)
            {
                try
                {
                    Console.WriteLine("Введите 2 числа, которые хотите спросить");
                    double a = Convert.ToInt32(Console.ReadLine());
                    double b = Convert.ToInt32(Console.ReadLine());
                    Calculator calculator = new Calculator();
                    Console.WriteLine(calculator.CalculateSum(a, b));
                    p = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Слагаемое введено не корректно");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
