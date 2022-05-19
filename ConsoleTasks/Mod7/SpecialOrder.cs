using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class SpecialOrder : Order<ShopDelivery>
    {
        public int DiscontPersent { get; private set; }
        public SpecialOrder(int id, ShopDelivery delivery, int size) : base(id, delivery)
        {
            DiscontPersent = 5;
        }
    }
}
