using GamersApp.Entities;
using GamersApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GamersApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest();
            }

            var user = await _context.Users.Where(x => x.Email == loginUser.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest("Wrong password");
            }

            if (!(BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password)))
            {
                PasswordFailedAttemp(user);
                return BadRequest("Wrong password");
            }
            else if (user.FailedPasswordAttempts >= 3)
            {
                return BadRequest("you are banned");
            }
            else
            {
                var tokenString = LogedInUserInfo(user);
                return Ok(new { Token = tokenString });
            }
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
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }

        private string LogedInUserInfo(User logedInUser)
        {
            ResetFailedAttempts(logedInUser);
            var claims = new[]
            {
                        new Claim(type: "id", value: logedInUser.Id.ToString()),
                        new Claim(type: "role", value:logedInUser.role.ToString()),
                    };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication@345"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7153",
                audience: "https://localhost:7153",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
                );
            var tokensString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);


            return tokensString;
        }

        private void PasswordFailedAttemp(User logedInUser)
        {
            logedInUser.FailedPasswordAttempts++;
            _context.SaveChangesAsync();
        }

        private void ResetFailedAttempts(User logedInUser)
        {
            logedInUser.FailedPasswordAttempts = 0;
            _context.SaveChangesAsync();
        }
    }
}