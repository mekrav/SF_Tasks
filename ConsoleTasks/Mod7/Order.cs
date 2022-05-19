using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class Order<TDelivery> where TDelivery : Delivery
    {
        public int Id { get; private set; }
        public TDelivery Delivery { get; private set; }
        OrderList OrderList { get; set; }

        public Order (int id, TDelivery delivery)
        {
            Id = id;
            Delivery = delivery;
            OrderList = new OrderList(); //Копмозиция
        }

        public static Order<TDelivery> operator + (Order<TDelivery> order, Product product)
        {
            order.OrderList = order.OrderList + product;
            return order;
        }

    }
}
