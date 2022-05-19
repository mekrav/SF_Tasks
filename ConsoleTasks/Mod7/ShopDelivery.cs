using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class ShopDelivery:Delivery
    {
        Shop Shop { get; set; }
        public override int DeliverySpeed(Addres addres)
        {
            return 2; //Хардкожу, ибо это не важно в данном контексте
        }
    }
}
