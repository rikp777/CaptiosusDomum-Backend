using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Context.Entities
{
    public class User
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Email { get; set; }
        
        [Required]
        public String Password { get; set; }
    }
}
