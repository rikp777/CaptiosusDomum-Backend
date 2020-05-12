using Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Entities
{
    public class RoomEntity
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }

        public RoomEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
