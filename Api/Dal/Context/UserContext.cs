using Api.Dal.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Context
{
    public class UserContext : IUserContext
    {
        private DatabaseContext _context;

        public UserContext(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> getUserByUsername(string username)
        {
            return await _context.User.FirstOrDefaultAsync(o => o.Username == username);
        }

        public async Task<UserEntity> registerNewUser(UserEntity user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            if (await _context.User.ContainsAsync(user))
            {
                return user;
            }
            return null;
        }
    }
}
