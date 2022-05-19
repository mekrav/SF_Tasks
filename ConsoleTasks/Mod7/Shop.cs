using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class Shop
    {
        public int Id { get; private set; }
        public Addres Addres { get; private set; }
        public Phone Phone { get; private set; }

        public Shop (int id, Addres addres, Phone phone) //Агрегация
        {
            Id = id;
            Addres = addres;
            Phone = phone;
        } 
    }
}
