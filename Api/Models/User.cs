using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Api
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


        public User()
        {
        }
    }
}
