using System.Threading.Tasks;
using Api.Api;
using Api.Api.EntityModels.User;
using Api.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userLogic;

        public AuthController(IUserService userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRegister user)
        {
            Models.User loggedInUser = await _userLogic.Authenticate(user.username, user.password);
            
            return Ok(loggedInUser);
        }

        [HttpPost("register")]
        public async Task<JsonResult> Register([FromBody] UserRegister user)
        {
            return new JsonResult(await _userLogic.Register(user.email, user.password));
        }

    }
}
