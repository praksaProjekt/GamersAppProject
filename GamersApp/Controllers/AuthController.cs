using GamersApp.Entities;
using GamersApp.Models;
using GamersApp.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthServices authServices;

        public AuthController(IAuthServices authServices)
        {
            this.authServices = authServices ?? throw new ArgumentNullException(nameof(authServices));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginUser)
        {
            string token = await authServices.Login(loginUser);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(User registerUser)
        {
            await authServices.Register(registerUser);
            return Ok();
        }
    }
}