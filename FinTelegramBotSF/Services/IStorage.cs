using System;
using System.Collections.Generic;
using System.Text;
using FinTelegramBotSF.Model;

namespace FinTelegramBotSF.Services
{
    internal interface IStorage
    {
        ///<summary>
        ///Получение сессии пользователя по идентификатору
        ///</summary>
        Session GetSession(long chatId);
    }
}
