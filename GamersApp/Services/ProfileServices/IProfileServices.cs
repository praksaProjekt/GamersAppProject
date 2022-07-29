using GamersApp.Entities;

namespace GamersApp.Services.ProfileServices
{
    public interface IProfileServices
    {
        Task<Profile> Get(int id);
        Task Put(Profile profile);
    }
}
