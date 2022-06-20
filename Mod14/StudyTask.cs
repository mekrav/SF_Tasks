using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Mod14
{
    internal class StudyTask
    {
        public static void Run()
        {
            //Запуск зсдачки из введения
            //Intro7();

            //14.1.1
            //t14_1_1();

            //14.1.6
            //t14_1_6();

            //14.2.3
            t14_2_3();


        }

        static void Intro7()
        {
            var objects = new List<object>()
            {
                1,
                "Сергей ",
                "Андрей ",
                300,
            };
            foreach (var s in objects.Where(p => p is string).OrderBy(p => p))
                Console.WriteLine(s);
        }

        static void t14_1_1()
        {
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Юрга", 80000));

            var res = russianCities.Where(c => c.Name.Length < 10).OrderBy(c => c.Name.Length);
            foreach (var c in res)
            {
                Console.WriteLine(c.Name);
            }
        }

        static void t14_1_6()
        {
            var numsList = new List<int[]>()
            {
                new[] {2, 3, 7, 1},
                new[] {45, 17, 88, 0},
                new[] {23, 32, 44, -6},
            };
            var orderedNums = numsList.SelectMany(s => s).OrderBy(s => s);
            foreach(var num in orderedNums)
            {
                Console.WriteLine(num);
            }
        }

        static void t14_2_3()
        {
            var cars = new List<Car>()
            {
                new Car("Suzuki", "JP"),
                new Car("Toyota", "JP"),
                new Car("Opel", "DE"),
                new Car("Kamaz", "RUS"),
                new Car("Lada", "RUS"),
                new Car("Lada", "RUS"),
                new Car("Honda", "JP"),
            };
            var result = cars.Where(c => c.Country != "JP");
            foreach(var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
