using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.User
{
    public class UserRegisterModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        //public UserRegisterModel(string username, string password, string email)
        //{
        //    this.username = username;
        //    this.password = password;
        //    this.email = email;
        //}

        //public UserRegisterModel()
        //{
        //}
    }
}
