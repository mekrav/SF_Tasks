using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks
{
    static class Mod5
    {
        static int ParseInt() //Строить костыли для обработки ошибок кажется злом
        {
            string Input = Console.ReadLine();
            int res = 0;
            if (!int.TryParse(Input,out res)) //Ограничено тремя знаками, ибо этого домтаточно и позволяет не отслеживать границы int
            {
                Console.WriteLine("Вы ввели что-то не так, попробуйте ещё раз");
                return ParseInt();
            }
            return res > 0 ? res : ParseInt();
        }
        static bool ParseBool()
        {
            string Input = Console.ReadLine();
            switch (Input)
            {
                case "Да":
                    return true;
                case "Нет":
                    return false;
                default:
                    Console.WriteLine("Вы ввели что-то не так, попробуйте ещё раз");
                    ParseBool();
                    break;
            }
            return false; //на самом деле никошда не выполнитса
        }

        static string[] PetParse(int PetCount)
        {
            string[] Pets = new string[PetCount];
            Console.WriteLine("Перечислите их клички"); 
            for (int i = 0; i < PetCount; i++) // Можно вынести этот цикл в отдельный метод, но мне кажется это лишним
            {
                Console.Write("{0}. ", i + 1);
                Pets[i] = Console.ReadLine();
            }
            return Pets;
        }

        static string[] ColorParse(int ColorCount)
        {
            string[] Pets = new string[ColorCount];
            Console.WriteLine("Перечислите их");
            for (int i = 0; i < ColorCount; i++) // Можно вынести этот цикл в отдельный метод, но мне кажется это лишним
            {
                Console.Write("{0}. ", i + 1);
                Pets[i] = Console.ReadLine();
            }
            return Pets;
        }
        public static (string FirstName, string SecondName, int Age, string[] Pets, string[] Colors) GetData()
        {
            Console.WriteLine("Введите имя:");
            string FirstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            string SecondName = Console.ReadLine();

            Console.WriteLine("Сколько Вам лет?");
            int Age = ParseInt();

            Console.WriteLine("У Вас есть питомец? (Да/Нет)");
            bool BoolPets = ParseBool();
            string[] Pets; //Если BoolPets = false, то будет пустым
            if (BoolPets)
            {
                Console.WriteLine("Сколько у вас питомцев?");
                int PetCount = ParseInt();
                Pets = PetParse(PetCount);
            }
            else  Pets = new string[0];

            Console.WriteLine("Сколько у Вас любимых цветов?");
            int ColorCount = ParseInt();
            string[] Colors = ColorParse(ColorCount);

            (string, string, int, string[], string[]) result = (FirstName, SecondName, Age, Pets, Colors);
            return result;
        }

        public static void ShowResult((string FirstName, string SecondName, int Age, string[] Pets, string[] Colors) Input)
        {
            Console.WriteLine("Имя: " + Input.FirstName);
            Console.WriteLine("Фамилия: " + Input.SecondName);
            Console.WriteLine("Возраст: " + Input.Age);
            if (Input.Pets != null)
            {
                Console.WriteLine("Питомцы:");
                foreach (string Pet in Input.Pets)
                {
                    Console.WriteLine("\t" + Pet);
                }
            }
            if (Input.Colors != null)
            {
                Console.WriteLine("Любимые цвета:");
                foreach (string Color in Input.Colors)
                {
                    Console.WriteLine("\t" + Color);
                }
            }

        }
    }
}