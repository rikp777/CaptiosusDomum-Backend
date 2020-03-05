using Interface.Entities;
using Interface.Interface;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AuthLogic: IAuthLogic
    {
        private readonly IUser _userContext;

        public AuthLogic()
        {
        }

        public AuthLogic(IUser user)
        {
            _userContext = user;
        }

        string GenerateUserToken()
        {
            return null;
        }

        public async Task<UserEntity> LoginUser(string username, string password)
        {
            UserEntity user = await _userContext.GetUserByUserName(username);

            if (BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
            { 
                return user;
            }

            else
            {
                return null;
            }
        }

        public async Task<UserEntity> RegisterUser(string username, string password, string email)
        {
            //UserEntity user = new UserEntity
            //{
            //    Username = username,
            //    Password = password,
            //    Email = email
            //};

            return await _userContext.Adduser(username, email, password);
        }
    }
}
