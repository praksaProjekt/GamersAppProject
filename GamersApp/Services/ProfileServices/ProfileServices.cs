using GamersApp.Entities;

namespace GamersApp.Services.ProfileServices
{
    public class ProfileServices : IProfileServices
    {
        private readonly DataContext context;

        public ProfileServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<Profile> Get(int id)
        {
            return await context.Profiles.FindAsync(id);
        }

        public async Task Put(Profile profile)
        {
            context.Profiles.Update(profile);
            await context.SaveChangesAsync();
        }
    }
}
