using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dal.Interface;
using Api.Logic.Interfaces;
using Api.Logic.Services.User;
using Api.Logic.Services.User.Helpers;
using Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Logic
{
    public class UserService : IUserService
    {
        private readonly IUserContext _userContext;

       
        //private List<Models.User> _users = new List<Models.User>
        //{
        //    new Models.User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        //};

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUserContext userContext)
        {
            _appSettings = appSettings.Value;
            _userContext = userContext;
        }


        public async Task<User> Register(string email, string password)
        { 
        //Encrypt password before storing it
        string encyptedpassword = BCrypt.Net.BCrypt.HashPassword(password);
        UserEntity newUser = new UserEntity(email, encyptedpassword, email);

        UserEntity userEntity = await _userContext.registerNewUser(newUser);

        if (userEntity.Id != 0)
        {
            return new User(userEntity.Username, userEntity.Password, userEntity.Email);
        }
            return null;
        }

    public async Task<User> Authenticate(string username, string password)
        {
            var user = await _userContext.SingleOrDefault(username);

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return new User(user.Username, user.Token);
        }

        public IEnumerable<User> GetAll()
        {
            //return _userContext.().WithoutPasswords();
            return null;
        }
    }
}
//{
//    public class UserLogic : IUserLogic
//{
//    private readonly UserManager<IdentityUser> _userManager;
//    private readonly SignInManager<IdentityUser> _signInManager;
//    private readonly JWTSettings _options;

//    private readonly IUserContext _userContext;

//    public UserLogic(
//        UserManager<IdentityUser> userManager,
//        SignInManager<IdentityUser> signInManager,
//        IOptions<JWTSettings> optionsAccessor,
//        IUserContext userContext)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//        _options = optionsAccessor.Value;
//        _userContext = userContext;
//    }

//    public async Task<User> Login(string username, string password)
//    {
//        UserEntity userEntity = await _userContext.getUserByUsername(username);

//        if (userEntity.Id != 0)
//        {
//            if (BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
//            {
//                return new User(userEntity.Username, userEntity.Password, userEntity.Email);
//            }
//        }
//        return null;
//    }

//    public async Task<JsonResult> Register(string email, string password)
//    {
//        var user = new IdentityUser { UserName = email, Email = email };
//        var result = await _userManager.CreateAsync(user, password);
//        if (result.Succeeded)
//        {
//            await _signInManager.SignInAsync(user, isPersistent: false);
//            return new JsonResult(new Dictionary<string, object>
//                {
//                    { "access_token", GetAccessToken(email) },
//                    { "id_token", GetIdToken(user) }
//                 });
//        }
//        return null;

//        //Encrypt password before storing it
//        //string encyptedpassword = BCrypt.Net.BCrypt.HashPassword(password);
//        //UserEntity newUser = new UserEntity(username, encyptedpassword, email);


//        //UserEntity userEntity = await _userContext.registerNewUser(newUser);

//        //if (userEntity.Id != 0)
//        //{
//        //    return new User(userEntity.Username, userEntity.Password, userEntity.Email);
//        //}
//        //return null;
//    }


//    private string GetIdToken(IdentityUser user)
//    {
//        var payload = new Dictionary<string, object>
//              {
//                { "id", user.Id },
//                { "sub", user.Email },
//                { "email", user.Email },
//                { "emailConfirmed", user.EmailConfirmed },
//              };
//        return GetToken(payload);
//    }

//    private string GetAccessToken(string Email)
//    {
//        var payload = new Dictionary<string, object>
//      {
//        { "sub", Email },
//        { "email", Email }
//      };
//        return GetToken(payload);
//    }

//    private string GetToken(Dictionary<string, object> payload)
//    {
//        var secret = _options.SecretKey;

//        payload.Add("iss", _options.Issuer);
//        payload.Add("aud", _options.Audience);
//        payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
//        payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
//        payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
//        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
//        IJsonSerializer serializer = new JsonNetSerializer();
//        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
//        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

//        return encoder.Encode(payload, secret);
//    }

//    private JsonResult Errors(IdentityResult result)
//    {
//        var items = result.Errors
//            .Select(x => x.Description)
//            .ToArray();
//        return new JsonResult(items) { StatusCode = 400 };
//    }

//    private JsonResult Error(string message)
//    {
//        return new JsonResult(message) { StatusCode = 400 };
//    }

//    private static double ConvertToUnixTimestamp(DateTime date)
//    {
//        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
//        TimeSpan diff = date.ToUniversalTime() - origin;
//        return Math.Floor(diff.TotalSeconds);
//    }
//}
//}