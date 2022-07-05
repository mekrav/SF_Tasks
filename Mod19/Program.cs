using System;
using Mod19.BLL.Exceptions;
using Mod19.BLL.Models;
using Mod19.BLL.Services;
using Mod19.PLL.Views;
using Dapper;
using System.Data;
using System.Data.SQLite;
using System.Linq;


namespace Mod19
{
    internal class Program
    {
        static MessageService messageService;
        static UserService userService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static AddFriendsView userFriendsView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            userFriendsView = new AddFriendsView();
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            while (true)
            {
                mainView.Show();
            }
        }
    }
}