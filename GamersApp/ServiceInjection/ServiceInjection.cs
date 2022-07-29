using GamersApp.Services.AuthServices;
using GamersApp.Services.FileServices;
using GamersApp.Services.PostServices;
using GamersApp.Services.FriendRequestServices;
using GamersApp.Services.FriendServices;
using GamersApp.Services.ProfileServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GamersApp.ServiceInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddJwtAuthenticationExtension(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "https://localhost:7153",
                    ValidAudience = "https://localhost:7153",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication@345"))
                };
            });

            return services;
        }

        public static IServiceCollection AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddDbContextExtension(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddServiceInjectionExtension(this IServiceCollection services)
        {
            services.AddTransient<IAuthServices, AuthServices>();
            services.AddTransient<IFileServices,FileServices>();
            services.AddTransient<IPostServices, PostServices>();
            services.AddTransient<IProfileServices, ProfileServices>();
            services.AddTransient<IFriendServices, FriendServices>();
            services.AddTransient<IFriendRequestServices, FriendRequestServices>();
            return services;
        }
    }
}