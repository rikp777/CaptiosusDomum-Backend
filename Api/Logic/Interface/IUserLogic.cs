using Api.Api;
using Api.Api.EntityModels.User;
using System.Threading.Tasks;

namespace Api.Logic.Interface
{
    public interface IUserLogic
    {
        Task<User> Login(string username, string password);
        Task<User> Register(string username, string email, string password);
    }
}
