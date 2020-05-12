﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Room
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
