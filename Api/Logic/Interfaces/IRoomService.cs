using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic.Interfaces
{
    public interface IRoomService
    {
        Task<Room> Add(Room room);
        Task<bool> Delete(int id);
        Task<Room> Update(Room room);
        Task<List<Room>> Get();
    }
}
