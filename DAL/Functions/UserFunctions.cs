using DAL.Context.ApplicationContext;
using DAL.Context.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunctions: IUser
    {
        public async Task<User> Adduser(string username, string email, string password)
        {
            User newuser = new User
            {
                Username = username,
                Email = email,
                Password = password
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Users.AddAsync(newuser);
                await context.SaveChangesAsync();
            }
            return newuser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }

    }
}
