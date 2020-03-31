using System.Threading.Tasks;
using Api.Logic.Interface;
using Api.Api;
using Api.Api.EntityModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public AuthController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost("login")]
        public async Task<JsonResult> Login([FromBody] UserRegister user)
        {
            User loggedInUser = await _userLogic.Login(user.username, user.password);
            return new JsonResult(loggedInUser);
        }

        [HttpPost("register")]
        public async Task<JsonResult> Register([FromBody] UserRegister user)
        {
            User newuser = await _userLogic.Register(user.username, user.email, user.password);
            return new JsonResult(newuser);
        }

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> Authenticate([FromBody] UserModel model)
        //{
        //    var user = await UserLogic.RegisterUser(model.username, model.password, model.email);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(user);
        //}

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> Authenticate([FromBody] UserModel model)
        //{
        //    var user = await UserLogic.RegisterUser(model.username, model.password, model.email);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<UserEntity> PostAsync([FromBody] string username, string password, string email)
        //{
        //    AuthLogic authLogic = new AuthLogic();
        //    return await authLogic.RegisterUser(username, password, email);
        //}

        //// GET: api/Auth/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Auth
        //[HttpGet]
        //public void Get()
        //{

        //}

        //// PUT: api/Auth/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
