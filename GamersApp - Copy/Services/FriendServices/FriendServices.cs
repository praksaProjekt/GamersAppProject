using GamersApp.DTO;
using GamersApp.Entities;

namespace GamersApp.Services.FriendServices
{
    public class FriendServices : IFriendServices
    {
        private readonly DataContext context;

        public FriendServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllFriends(int id)
        {
            //return await context.Friends.GetAllFriends(id);
            throw new NotImplementedException();
        }

        public async Task RemoveFriend(int UserID, int id)
        {
            var toDeleteFriend = await context.Friends.Where(f => (f.UserID2 == UserID && f.UserID1 == id)
                                                                 || (f.UserID1 == UserID && f.UserID2 == id)).FirstOrDefaultAsync();

            if (toDeleteFriend != null)
            {
                context.Friends.Remove(toDeleteFriend);
                context.SaveChanges();
            }
        }
    }
}
