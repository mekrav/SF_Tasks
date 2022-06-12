using System;
using System.Collections.Generic;
using System.Text;

namespace FinTelegramBotSF.Utilities
{
    internal static class Sum
    {
        public static double Count(string data){
            data = data.Replace('.', ','); //Поддержка записи и через "." и через ","
            string[] nums = data.Split(' ');
            double sum = 0;
            double num;
            foreach (string s in nums)
            {
                if (double.TryParse(s, out num))
                {
                    sum += num;
                }
                else throw new ArgumentOutOfRangeException($"Введено не число: {s}");
            }
            return sum;
        }
                
    }
}
