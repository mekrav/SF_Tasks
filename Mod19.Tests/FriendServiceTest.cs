using System;
using Mod19.BLL.Services;
using Mod19.BLL.Models;
using NUnit.Framework;

namespace Mod19.Tests
{
    [TestFixture]
    public class FriendServiceTest
    {
        [Test]
        public void AddNewFriendShouldThrowException()
        {
            var friendAddingData = new FriendAddingData()
            {
                UserId = 1,
                FriendEmail = "jkjk"
            };
            var friendService = new FriendService();
            Assert.Throws<ArgumentNullException>(() => friendService.AddNewFriend(friendAddingData));
        }
    }
}
