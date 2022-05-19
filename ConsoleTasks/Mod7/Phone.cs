using System;
using System.Collections.Generic;
using System.Text;
#nullable enable

namespace ConsoleTasks.Mod7
{
    internal class Phone
    {
        static string[] CountryCodes = {"+7", "8"}; //О, у России и Казахстана одинаковый код
        string? number = null;
        public string Number
        {
            get { return number; } //Нужна обработка ошибок
            set
            {
                if (Array.IndexOf(CountryCodes, value[0].ToString()) != -1 && value[1..].IsPhoneNumber())
                {
                    number = value;
                }
                else if (Array.IndexOf(CountryCodes, value.Substring(0, 1)) != -1 && value[2..].IsPhoneNumber())
                {
                    number = value;
                }
                else
                {
                    Console.WriteLine("К сожалению мы пока не работаем в Вашей стране"); //По-хорошему нужно кинуть ошибку
                }
            }
        }
    }
}
