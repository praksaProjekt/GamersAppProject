using GamersApp.DTO;

namespace GamersApp.Services.FriendServices
{
    public interface IFriendServices
    {
        Task<IEnumerable<UserModel>> GetAllFriends(int id);
        Task RemoveFriend(int UserID, int id);
    }
}
