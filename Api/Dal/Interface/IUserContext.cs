using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Interface
{
    public interface IUserContext
    {
        Task<UserEntity> getUserByUsername(string username);
        Task<UserEntity> registerNewUser(UserEntity user);
    }
}
