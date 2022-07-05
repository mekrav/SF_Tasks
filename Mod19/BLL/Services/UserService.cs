using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mod19.BLL.Models;
using Mod19.BLL.Exceptions;
using Mod19.DAL.Repositories;
using Mod19.DAL.Entities;

namespace Mod19.BLL.Services
{
    internal class UserService
    {
        IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }
        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            //Hardcoded 8
            if(userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            if(!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if(findUserEntity is null) 
                throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatebleUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };
            if (this.userRepository.Update(updatebleUserEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            return new User(userEntity.id,
                            userEntity.firstname,
                            userEntity.lastname,
                            userEntity.password,
                            userEntity.email,
                            userEntity.photo,
                            userEntity.favorite_movie,
                            userEntity.favorite_book);
        }
    }
}