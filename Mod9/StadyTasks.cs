using System;
using System.Collections.Generic;
using System.Text;

namespace Mod9
{
    internal static class StadyTasks
    {
        public static void Run()
        {
            /* 9.2.2; 9.2.3
            TCF(true);
            TCF(false);
            */

            /* 9.3.3 - 9.3.5 
            DeligateDemo SubSumDeligate = SubDelegateDemo;
            Console.WriteLine(SubSumDeligate.Invoke(7, 3));
            Console.WriteLine(SubSumDeligate(7, 3));
            SubSumDeligate += SumDelegateDemo;
            SubSumDeligate(10, 5);
            SubSumDeligate -= SubDelegateDemo;
            SubSumDeligate(10, 5);
            */

            /* 9.3.8
            Func<int, int, int> SubFuncDemo = SubDelegateDemo;
            Console.WriteLine(SubFuncDemo(10, 5));
            Action<bool> TCFActionDemo = TCF;
            TCFActionDemo(false);
            Predicate<int> PredicateDemo = PredDemo;
            Console.WriteLine(PredicateDemo(5));
            */

            /* 9.3.12 Анонимный метод
            ShowDemo demo = delegate ()
            {
                Console.WriteLine("Chookity-pok");
            };
            demo();
            */

            /* 9.3.12 
            DeligateDemo LambdaDenmo = (a, b) => a * b;
            Console.WriteLine(LambdaDenmo(2,5));
            */

            /* 9.4.2; 9.4.3

            Co co = CoMethod;
            co();

            Child p = null;
            Contr contr = ContrMethood; //Делегат накладывает ограничение на параметр
            contr(p);
            */

        }

        static void SimpleExeption()
        {
            Exception exception = new Exception("First Castom Exception");
            exception.Data.Add("Дата создания:", DateTime.Now);
            exception.HelpLink = "code.you.com";
        }

        static void TCF(bool k)
        {
            try
            {
                if (k)
                    throw new RankException("Bupbup");
                else 
                    throw new ArgumentOutOfRangeException("Bup");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (RankException ex)
            {
                Console.WriteLine(ex.GetType());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        delegate int DeligateDemo(int a, int b);
        static int SubDelegateDemo(int a, int b)
        {
            Console.WriteLine(a - b);
            return a-b;
        }
        static int SumDelegateDemo(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }
        static bool PredDemo(int a)
        {
            return a>0;
        }

        delegate void ShowDemo();

        // Ковариантность
        class Car { }
        class Lexus: Car { }
        delegate Car Co();
        static Lexus CoMethod()
        {
            Console.WriteLine("Co");
            return null;
        }

        // Контрвариантность
        class Parent { }
        class Child: Parent { }
        delegate void Contr(Child c);
        static void ContrMethood(Parent p)
        {
            Console.WriteLine("Contr");
        }
    }
}
