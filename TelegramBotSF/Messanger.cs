using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotSF
{
    internal class Messanger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";
            string command = chat.GetLastMessage();
            switch (command) {
                case "/saymehi":
                    text = "Привет!";
                    break;
                case "/askme":
                    text = "Как дела?";
                    break;
                default:
                    var delimiter = ", ";
                    text = "History: " + string.Join(delimiter, chat.GetTextMessage().ToArray());
                    break;
            }
            return  text;
        }
    }
}
