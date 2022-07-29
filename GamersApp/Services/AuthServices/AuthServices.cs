using GamersApp.DTO;
using GamersApp.Entities;
using GamersApp.Middleware;
using GamersApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GamersApp.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly DataContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AuthServices(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;   
        }

        public async Task<string> Login(LoginModel loginUser)
        {
            var user = await context.Users.Where(x => x.Email == loginUser.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new AppException("Wrong email or password", 403);
            }

            if (!(BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password)))
            {
                PasswordFailedAttemp(user);
                throw new AppException("Wrong email or password", 403);
            }
            else if (user.FailedPasswordAttempts >= 3)
            {
                throw new AppException("Banned", 403);
            }

            var tokenString = GetJwt(user);
            return tokenString;
        }

        public async Task Register(User registerUser)
        {
            var user = await context.Users.Where(u => u.Email == registerUser.Email).FirstOrDefaultAsync();

            if (user != null)
            {
                throw new AppException("User already exists", 403);
            }

            registerUser.Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            await context.Users.AddAsync(registerUser);
            await context.SaveChangesAsync();

            Profile profile = new()
            {
                UserId = registerUser.Id,
                ProfilePictureURI = "baseImage.jpg"
            };

            await context.Profiles.AddAsync(profile);
            await context.SaveChangesAsync();
        }

        private string GetJwt(User logedInUser)
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
            context.SaveChangesAsync();
        }

        private void ResetFailedAttempts(User logedInUser)
        {
            logedInUser.FailedPasswordAttempts = 0;
            context.SaveChangesAsync();
        }
    }
}
