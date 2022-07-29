using GamersApp.DTO;
using GamersApp.Entities;

namespace GamersApp.Services.FriendRequestServices
{
    public class FriendRequestServices
    {
        private readonly DataContext context;

        public FriendRequestServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllRequestsPending(int UserID)
        {
            return await context.Users.Where(u => u.Id == UserID)
                                      .SelectMany(x => x.FriendRequestsThem
                                      .Select(x => new FriendRequestModel { Email = x.FollowerUser.Email, Id = x.FollowerUser.Id }
                                      )).ToListAsync();
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllRequestsSent(int UserID)
        {
            return await context.Users.Where(u => u.Id == UserID)
                                     .SelectMany(x => x.FriendRequestsMe
                                     .Select(x => new FriendRequestModel { Email = x.FollowerUser.Email, Id = x.FollowerUser.Id }
                                     )).ToListAsync();
        }

        public void SendFriendRequest(int UserID, int id)
        {
            FriendRequest newFriendRequest = new()
            {
                Followed = id,
                Follower = UserID
            };

            context.FriendRequests.Add(newFriendRequest);
            context.SaveChanges();
        }

        public async Task AcceptFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await context.FriendRequests.Where(f => ((f.Followed == UserID && f.Follower == id)
                                                                          || (f.Follower == UserID && f.Followed == id))).FirstOrDefaultAsync();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
            }

            var newFriend = new Friend
            {
                UserID1 = id,
                UserID2 = UserID
            };

            context.Friends.Add(newFriend);
            context.SaveChanges();
        }

        public async Task RemoveFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await context.FriendRequests.Where(f => ((f.Followed == UserID && f.Follower == id)
                                                                          || (f.Follower == UserID && f.Followed == id))).FirstOrDefaultAsync();

            if (toDeleteRequest != null)
            {
                context.FriendRequests.Remove(toDeleteRequest);
                context.SaveChanges();
            }
        }
    }
}
