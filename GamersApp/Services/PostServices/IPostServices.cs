using GamersApp.DTO;
using GamersApp.Entities;

namespace GamersApp.Services.PostServices
{
    public interface IPostServices
    {
        Task<Post> AddPost(PostModel postData);
        Task<PostViewModel> FindPost(int id);
        Task<IEnumerable<PostViewModel>> GetUserPosts(int userID);
        Task ChangeLikes(int id, bool value, int userId);

        Task RemoveLike(int likeId);
    }
}
