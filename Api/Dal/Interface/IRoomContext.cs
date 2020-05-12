using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Interface
{
    public interface IRoomContext
    {
        Task<Room> Add(Room room);
        Task<bool> Delete(int id);
        Task<Room> Update(Room room);
        Task<List<Room>> Get();
    }
}
