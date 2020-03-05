using Api.Dal.Interface;
using Api.Logic.Interface;
using Api.Models;
using Api.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserContext _userContext;

        public UserLogic(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<UserRegisterModel> Login(string username, string password)
        {
            UserEntity userEntity = await _userContext.getUserByUsername(username);

            if (userEntity.Equals(default))
            {
                if (BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
                {
                    return new UserRegisterModel(userEntity.Username, userEntity.Password, userEntity.Email);
                }
            }
            return null;
        }

        public async Task<UserRegisterModel> Register(string username, string email, string password)
        {
            //Encrypt password before storing it
            string encyptedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            UserEntity newUser = new UserEntity(username, encyptedpassword, email);


            UserEntity userEntity = await _userContext.registerNewUser(newUser);
           
            if (userEntity.Equals(default(UserEntity)))
            {
                return new UserRegisterModel(userEntity.Username, userEntity.Password, userEntity.Email);
            }
            return null;
        }
    }
}
