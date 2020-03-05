using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class UserEntity
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Username { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string Email { get; private set; }

        public UserEntity(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public UserEntity(string username, string password, string email)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
