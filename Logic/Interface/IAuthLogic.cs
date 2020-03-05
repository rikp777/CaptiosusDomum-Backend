using Interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface IAuthLogic
    {
        Task<UserEntity> LoginUser(string username, string password);
        Task<UserEntity> RegisterUser(string username, string password, string email);
    }
}
