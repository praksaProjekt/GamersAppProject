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
            var dbUser = await _context.Users.Where(u => u.Email == newUser.Email).FirstOrDefaultAsync();

            if (dbUser != null)
            {
                return BadRequest("User already exists");
            }

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            Profile profile = new()
            {
                Id = newUser.Id
            };
            _context.Profiles.Add(profile);
            return Ok(newUser);
        }
    }
}
