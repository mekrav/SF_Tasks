using System;
using System.Collections.Generic;
using System.Text;
using ReTelegramBotSF.Model;

namespace ReTelegramBotSF.Services
{
    internal interface IStorage
    {
        ///<summary>
        ///Получение сессии пользователя по идентификатору
        ///</summary>
        Session GetSession(long chatId);
    }
}
