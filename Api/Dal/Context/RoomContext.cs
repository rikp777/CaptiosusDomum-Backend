using Api.Dal.Entities;
using Api.Dal.Interface;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Context
{
    public class RoomContext : IRoomContext, IDisposable
    {
        private RepositoryContext _context;

        public RoomContext(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Room> Add(Room room)
        {
            RoomEntity newroom = new RoomEntity(room.Id, room.Name, room.Description);
            await _context.Room.AddAsync(newroom);
            await _context.SaveChangesAsync();

            if (await _context.Room.ContainsAsync(newroom))
            {
                return room;
            }
            return null;
        }

        public async Task<bool> Delete( int id)
        {
            var roomEntity = await  _context.Room.FirstOrDefaultAsync(o => o.Id == id);
            _context.Room.Remove(roomEntity);

            await _context.SaveChangesAsync();

            if (await _context.Room.ContainsAsync(roomEntity))
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Room>> Get()
        {
            List<Room> rooms = new List<Room>();
            List<RoomEntity> roomEntities = await _context.Room.ToListAsync();
            foreach (var room in roomEntities)
            {
                rooms.Add(new Room(room.Id, room.Name, room.Description));
            }
            return rooms;
        }

        public async Task<Room> Update(Room room)
        {
            var editedobject = await _context.Room.FirstOrDefaultAsync(o => o.Id == room.Id);
            _context.Entry(editedobject).CurrentValues.SetValues(room);

            await _context.SaveChangesAsync();

            return room;
        }
    }
}
