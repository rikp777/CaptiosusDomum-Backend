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
        [Required]
        public string Description { get; private set; }

        public RoomEntity()
        {
        }



        public RoomEntity(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is RoomEntity entity &&
                   Id == entity.Id &&
                   Name == entity.Name &&
                   Description == entity.Description;
        }
    }
}
