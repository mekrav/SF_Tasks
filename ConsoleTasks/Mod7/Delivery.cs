using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal abstract class Delivery
    {
        public string ClientName { get; private set; }
        public Phone ClientPhone { get; private set; }

        public abstract int DeliverySpeed(Addres addres);

    }
}
