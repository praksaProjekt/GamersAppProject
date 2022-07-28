using GamersApp.Models;

namespace GamersApp.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<string> Login(LoginModel user);
        Task Register(RegisterModel user);

    }
}
