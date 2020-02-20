using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Structs
{
    public class UserStruct
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public UserStruct(string Name, string LastName, string Mail, string Password)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Mail = Mail;
            this.Password = Password;
        }
    
    }
}
