using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Mod9
{
    internal static class Task1
    {
        public static void Run()
        {
            //Задание 1
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new MemberAccessException("0");
            exceptions[1] = new StackOverflowException("1");
            exceptions[2] = new Task1_Ex("2-)");
            exceptions[3] = new ReadOnlyException("3");
            exceptions[4] = new VersionNotFoundException("4");
            for (int i = 0; i < exceptions.Length; i++)
            {
                try
                {
                    throw exceptions[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " - " + ex.GetType());
                }
            }
        }
    }
}
