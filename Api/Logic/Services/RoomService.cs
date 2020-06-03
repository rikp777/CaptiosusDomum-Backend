using Api.Dal.Interface;
using Api.Logic.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic.Services
{
    public class RoomService: IRoomService
    {
        //private readonly IUserContext _userContext;
        private readonly IRoomContext _roomContext;

        public RoomService()
        {}

        public RoomService(IRoomContext roomContext)
        {
            //_userContext = userContext;
            _roomContext = roomContext;
        }

        public Task<Room> Add(Room room)
        {
            return _roomContext.Add(room);
        }

        public Task<bool> Delete(int id)
        {
            return _roomContext.Delete(id);
        }

        public Task<List<Room>> Get()
        {
            return _roomContext.Get();

        }

        public Task<Room> Update(Room room)
        {
            return _roomContext.Update(room);
        }
    }
}
