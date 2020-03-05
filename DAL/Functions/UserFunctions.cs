using DAL.Context.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.Interface;
using Interface.Entities;

namespace DAL.Functions
{
    public class UserFunctions: IUser
    {
        public async Task<UserEntity> Adduser(string username, string email, string password)
        {
            UserEntity newuser = new UserEntity 
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

        public async Task<List<UserEntity>> GetAllUsers()
        {
            List<UserEntity> users = new List<UserEntity>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }

        public async Task<UserEntity> GetUserByUserName(string username)
        {
            UserEntity user = null;
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                user = await context.Users.FindAsync(context.Users.Where(o => o.Username == username));
            }
            return user;
        }
    }
}
