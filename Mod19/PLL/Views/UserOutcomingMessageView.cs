﻿using Mod19.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod19.PLL.Views
{
    internal class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            Console.WriteLine("Исходящие сообщения");

            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                return;
            }

            outcomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("Кому: {0}. Текст сообщения: {1}", message.RecipientEmail, message.Content);
            });
        }
    }
}
