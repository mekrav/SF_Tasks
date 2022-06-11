using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ReTelegramBotSF.Extensions
{
    internal class DirectoryExtensions
    {
        public static string GetSolutionRoot()
        {
            ///<summary>
            ///Получаем путь до каталога с .sln файлом
            ///</summary>
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullName = Directory.GetParent(dir).FullName;
            var projectRoot = fullName.Substring(0, fullName.Length - 4); //.sin ???
            return Directory.GetParent(projectRoot)?.FullName;
        }
    }
}
