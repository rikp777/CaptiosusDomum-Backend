using System.Threading.Tasks;
using Api.Api;
using Api.Api.EntityModels.Room;
using Api.Api.EntityModels.User;
using Api.Logic.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomlogic;

        public RoomController(IRoomService roomLogic)
        {
            _roomlogic = roomLogic;
        }

        [HttpPost("create")]
        public async Task<JsonResult> Create(RoomEntityModel room)
        {
            return new JsonResult(await _roomlogic.Add(new Room(0, room.Name, room.Description)));
        }

        [HttpPost("delete")]
        public async Task<JsonResult> Delete(RoomEntityModel room)
        {
            return new JsonResult(await _roomlogic.Delete(room.Id));
        }

        [HttpPost("update")]
        public async Task<JsonResult> Update(RoomEntityModel room)
        {
            return new JsonResult(await _roomlogic.Update(new Room(room.Id, room.Name, room.Description)));
        }

        [HttpPost("get")]
        public async Task<JsonResult> Get()
        {
            return new JsonResult(await _roomlogic.Get());
        }

    }
}
