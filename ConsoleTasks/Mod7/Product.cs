using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class Product
    {
        public int Id { get; private set; } //уверена что так не делают, но пусть будет
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int stock { get; private set; } //запас на складе
    }
}
