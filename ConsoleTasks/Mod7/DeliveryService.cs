using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class DeliveryService //Этот класс может так же хранить регионы в которых работает эта служба и способ получения стоимости доставки
    {
        public string Name { get; private set; }
        public Phone phone { get; private set; }
        public enum DeliveryTypes
        {
            Home,
            PickPoint
        }
        public bool[] PossibleDeliveryTypes { get; private set; }
    }
}
