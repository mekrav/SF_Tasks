using System;
using System.Collections.Generic;
using System.Text;

namespace Mod9
{
    internal class Task2_Reader
    {
        public delegate void SortingOrder(string[] unsortedList, int number);
        public event SortingOrder SortingOrderEvent;
        public void ReadOrder(string[] data)
        {
            Console.WriteLine("Введите 1 для сортировки списка фамилий от А до Я. \n " +
                              "Введите 2 для сортировки списка фамилий от Я до А.");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2)
                throw new FormatException();
            OrderChosen(data, number);
        }
        protected virtual void OrderChosen(string[] data, int num)
        {
            SortingOrderEvent?.Invoke(data, num);
        }

    }
}
