using Interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IUser
    {
        Task<UserEntity> Adduser(string username, string email, string password);
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserByUserName(string username);
    }
}
