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
        private RepositoryContext _context;

        public UserContext(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> SingleOrDefault(string username)
        {
            return await _context.User.SingleOrDefaultAsync(x => x.Username == username);
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

        public Task<UserEntity> getUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
