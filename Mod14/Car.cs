using System;
using System.Collections.Generic;
using System.Text;

namespace Mod14
{
    internal class Car
    {
        public string Model { get; set; }
        public string Country { get; set; }
        public Car(string model, string country)
        {
            Model = model;
            Country = country;
        }
    }
}
