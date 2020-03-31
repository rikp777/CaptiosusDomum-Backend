using Api.Dal.Interface;
using Api.Logic.Interface;
using Api.Api;
using Api.Api.EntityModels.User;
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

        public async Task<User> Login(string username, string password)
        {
            UserEntity userEntity = await _userContext.getUserByUsername(username);

            if (userEntity.Id != 0)
            {
                if (BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
                {
                    return new User(userEntity.Username, userEntity.Password, userEntity.Email);
                }
            }
            return null;
        }

        public async Task<User> Register(string username, string email, string password)
        {
            //Encrypt password before storing it
            string encyptedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            UserEntity newUser = new UserEntity(username, encyptedpassword, email);


            UserEntity userEntity = await _userContext.registerNewUser(newUser);
           
            if (userEntity.Id != 0)
            {
                return new User(userEntity.Username, userEntity.Password, userEntity.Email);
            }
            return null;
        }
    }
}
