using ReTelegramBotSF.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ReTelegramBotSF.Services
{
    internal class MemoryStorage : IStorage
    {
        /// <summary>
        /// Session storage
        /// </summary>
        private readonly ConcurrentDictionary<long, Session> _sessions;
        public MemoryStorage()
        {
            _sessions = new ConcurrentDictionary<long, Session>();
        }
        public Session GetSession(long chatId)
        {
            if (_sessions.ContainsKey(chatId))
                return _sessions[chatId];
            var newSession = new Session() { LanguageCode = "ru"};
            _sessions.TryAdd(chatId, newSession);
            return newSession;
        }
    }
}
