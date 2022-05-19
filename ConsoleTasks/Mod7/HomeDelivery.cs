using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class HomeDelivery: Delivery
    {
        public Addres Addres { get; private set; }
        public DeliveryService DeliveryService { get; private set; }
        public override int DeliverySpeed(Addres addres)
        {
            return 3; //Хардкожу, ибо это не важно в данном контексте
        }
    }
}
