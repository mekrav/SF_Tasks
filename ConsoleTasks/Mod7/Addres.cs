using System;
using System.Collections.Generic;
using System.Text;
#nullable enable

namespace ConsoleTasks.Mod7
{
    internal class Addres
    {
        static string[] AvailableCountries = {"Россия", "Казахстан"}; //Страны в которые есть возможность доставить товар
        string? country;
        public string? Country {
            get { return country; } 
            set 
            {
                if (Array.IndexOf(AvailableCountries, value) != -1) 
                {
                    country = value;
                }
                else
                {
                    Console.WriteLine("К сожалению, мы пока не осуществляем доставку в эту страну"); //Нужно кинуть ошибку
                }
            } 
        }
        string? Region { get; set; }
        string? City { get; set; }
        string? Strit { get; set; }
        string? HouseNumber { get; set; }//Думаю что это всё хранится в другом формате, но оставлю так ибо н
        
        public Addres(string country, string region, string city, string strit, string HouseNumber)
        {
            this.Country = country;
            this.Region = region;
            this.City = city;
            this.Strit = strit;
            this.HouseNumber = HouseNumber; //Можно добавить кучу проверок, но я не уверена что это нужно здесь и что за этим не ходят во внешние сервисы
        }
    }
}
