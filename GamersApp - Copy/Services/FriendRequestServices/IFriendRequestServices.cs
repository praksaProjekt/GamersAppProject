using GamersApp.DTO;

namespace GamersApp.Services.FriendRequestServices
{
    public interface IFriendRequestServices
    {
        Task<IEnumerable<FriendRequestModel>> GetAllRequestsPending(int UserID);
        Task<IEnumerable<FriendRequestModel>> GetAllRequestsSent(int UserID);
        void SendFriendRequest(int UserID, int id);
        Task AcceptFriendRequest(int UserID, int id);
        Task RemoveFriendRequest(int UserID, int id);
    }
}
