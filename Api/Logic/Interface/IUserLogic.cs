using Api.Models.User;
using System.Threading.Tasks;

namespace Api.Logic.Interface
{
    public interface IUserLogic
    {
        Task<UserRegisterModel> Login(string username, string password);
        Task<UserRegisterModel> Register(string username, string email, string password);
    }
}
