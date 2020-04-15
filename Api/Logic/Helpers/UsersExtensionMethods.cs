using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic.Services.User.Helpers
{
    public static class UsersExtensionMethods
    {
        public static IEnumerable<UserEntity> WithoutPasswords(this IEnumerable<UserEntity> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserEntity WithoutPassword(this UserEntity user)
        {
            user.Password = null;
            return user;
        }
    }
}
