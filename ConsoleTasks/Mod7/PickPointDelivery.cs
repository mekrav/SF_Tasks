using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class PickPointDelivery:Delivery
    {
        DeliveryService DeliveryService { get; set; }
        public override int DeliverySpeed(Addres addres)
        {
            return 1; //Хардкожу, ибо это не важно в данном контексте
        }
    }
}
