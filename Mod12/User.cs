using System;
using System.Collections.Generic;
using System.Text;

namespace Mod12
{
    internal class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }

        User (string login, string name, bool isPremium)
        {
            Login = login;
            Name = name;
            IsPremium = isPremium;
        }
        public static User[] ParseArgs(string[] data)
        {
            //Просто заглушка
            return null;
        }
    }
}
