using Mod19.BLL.Exceptions;
using Mod19.BLL.Models;
using Mod19.DAL.Entities;
using Mod19.DAL.Repositories;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Mod19.BLL.Services
{
    internal class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        UserService userService;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
            userService = new UserService();
        }

        public void AddNewFriend(FriendAddingData friendAddingData)
        {
            if (!new EmailAddressAttribute().IsValid(friendAddingData.FriendEmail))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity
            {
                user_id = friendAddingData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
