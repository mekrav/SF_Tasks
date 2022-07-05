using Mod19.BLL.Models;
using Mod19.BLL.Services;
using Mod19.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mod19.PLL.Views
{
    internal class AddFriendsView
    {
        FriendService friendService;
        public AddFriendsView()
        {
            friendService = new FriendService();
        }
        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();
            friendAddingData.UserId = user.Id;
            Console.WriteLine("Введите e-mail друга, которого хотите добавить");
            friendAddingData.FriendEmail = Console.ReadLine();

            try
            {
                friendService.AddNewFriend(friendAddingData);
                SuccessMessage.Show("Новый друг успешно добавлен!");
            }
            catch
            {

            }
        }
    }
}
