using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Api.EntityModels.User
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }

        public UserLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public UserLogin()
        {
        }
    }
}
