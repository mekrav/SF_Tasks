using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mod9
{
    internal class Task2
    {
        public static void Run()
        {
            Task2_Reader reader = new Task2_Reader();
            reader.SortingOrderEvent += ShowInChosenOrder;
            bool p = true;
            while (p)
            {
                try
                {
                    var UnsortedList = GetArray("D:\\path\\UnsortedList.txt");
                    reader.ReadOrder(UnsortedList);
                    p = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Значение введено не корректно");
                }
            }
        }

        static string[] GetArray(string path)
        {
            string[] res;
            res = File.ReadAllLines(path);
            return res;
        }

        static void ShowInChosenOrder(string[] list, int number)
        {
            switch (number)
            {
                case 1: SortArray(list); break;
                case 2: IgSortArray(list); break;
            }
            foreach(string e in list)
            {
                Console.WriteLine(e);
            }
        }

        static void SortArray(string[] unsortedArray)
        {
            Array.Sort(unsortedArray, StringComparer.InvariantCultureIgnoreCase);
        }
        static void IgSortArray(string[] unsortedArray)
        {
            Array.Sort(unsortedArray, StringComparer.InvariantCultureIgnoreCase);
            Array.Reverse(unsortedArray);
        }
    }
}
