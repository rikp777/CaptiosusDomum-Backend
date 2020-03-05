using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interface.Entities
{
    public class UserEntity
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        //public UserStruct(string Name, string LastName, string Mail, string Password)
        //{
        //    this.Name = Name;
        //    this.LastName = LastName;
        //    this.Mail = Mail;
        //    this.Password = Password;
        //}
    
    }
}
