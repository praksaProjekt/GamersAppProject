using GamersApp.Entities;
using GamersApp.Models;

namespace GamersApp.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<string> Login(LoginModel loginUser);
        Task Register(User registerUser);

    }
}
