using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotSF
{
    internal class Conversation
    {
        Chat telegramChat;
        List<Message> telegramMessages;
        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }
        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }
        public List <string> GetTextMessage()
        {
            var textMessages = new List<string>();
            foreach(var message in telegramMessages)
            {
                textMessages.Add(message.Text);
            }
            return textMessages;
        }
        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
    }
}