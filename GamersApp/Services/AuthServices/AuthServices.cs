using GamersApp.Models;

namespace GamersApp.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        Task<string> IAuthServices.Login(LoginModel user)
        {
            throw new NotImplementedException();
        }

        Task IAuthServices.Register(RegisterModel user)
        {
            throw new NotImplementedException();
        }
    }
}
