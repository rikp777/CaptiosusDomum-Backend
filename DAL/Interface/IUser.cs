using DAL.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUser
    {
        Task<User> Adduser(string username, string email, string password);
        Task<List<User>> GetAllUsers();
    }
}
