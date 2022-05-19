using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTasks.Mod7
{
    internal class OrderList
    {
        (Product, int)[] ListOfProducts;
        int OrderSize = 0;
        static int MaxSize; 
        public OrderList ()
        {
            ListOfProducts = new (Product, int)[MaxSize];
            OrderSize = 0;
        }
        public (Product product, int amount) this [int index]
        {
            get
            {
                if (index < this.OrderSize)
                {
                    return ListOfProducts[index];
                }
                else return (new Product(), -1); //Мне всё ещё отчаяно необходима обработка ошибок
            }
            private set
            {
                if (index < this.OrderSize)
                {
                    ListOfProducts[index] = value;
                }
                else Console.WriteLine("Выход за границу массива"); //Мне всё ещё отчаяно необходима обработка ошибок
            }
        }

        public static OrderList operator +(OrderList list, Product product)
        {
            /* Нет имплементации, но идея в том что бы найти продукт и инкременировать его количество,иначк добавить новый элемент */
            return list;            
        }
    }
}
