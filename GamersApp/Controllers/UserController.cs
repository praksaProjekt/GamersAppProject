using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
 
        public async Task<ActionResult<User>> AddUser(User newUser)
        {
            var dbUser = _context.Users.Where(u => u.Email == newUser.Email).FirstOrDefault();

            if (dbUser != null)
            {
                return BadRequest("User already exist");
            }

            string changingPass = newUser.Password;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(changingPass);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }
    }
}
