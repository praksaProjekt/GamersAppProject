using GamersApp.DTO;
using GamersApp.Entities;
using GamersApp.Services.FileServices;

namespace GamersApp.Services.PostServices
{
    public class PostServices: IPostServices
    {
        private readonly DataContext context;
        private readonly IFileServices fileService;

        public PostServices(DataContext context, IFileServices fileService)
        {
            this.context = context;
            this.fileService = fileService;
        }

        public async Task<Post> AddPost(PostModel postData)
        {
            Post newPost = new()
            {
                UserId = postData.UserId,
                Body = postData.Body,
                PostType = postData.PostType,
                DatePublished = DateTime.Now
            };

            var path = await fileService.UploadFileAsync(new FileModel()
            {
                UserId = postData.UserId,
                FileBase64 = postData.FileBase64,
                Filename = postData.Filename,
                FileType = (fileType)postData.PostType + 1
            });
            newPost.fileURI = path;

            await context.AddAsync(newPost);
            await context.SaveChangesAsync();

            return newPost;
        }

        public async Task<PostViewModel> FindPost(int id)
        {
            var postView = await context.Posts.Where(x => x.Id == id).Include(u => u.User).Include(u=>u.Likes).Select(x => new PostViewModel
            {
                Body = x.Body,
                Id = x.Id,
                UserId = x.UserId,
                FileURI = x.fileURI,
                Likes = x.Likes.Sum(v => v.Liked ? 1 : -1),
                Nickname = x.User!.Nickname,
                PostType = x.PostType
            }).FirstOrDefaultAsync(); ;

            return postView!;
        }

        public async Task<IEnumerable<PostViewModel>> GetUserPosts(int userID)
        {
            return await context.Posts.Where(x => x.UserId == userID).Include(u => u.User).Include(u => u.Likes).Select(x => new PostViewModel
            {
                Body = x.Body,
                Id = x.Id,
                UserId = x.UserId,
                FileURI = x.fileURI,
                Likes = x.Likes.Sum(v => v.Liked ? 1 : -1),
                Nickname = x.User!.Nickname,
                PostType = x.PostType
            }).ToListAsync();
        }

        public async Task ChangeLikes(int id, bool value, int userId)
        {
            var likedPost = await context.PostLikes.Where(x => x.UserId == userId && x.PostId == id).FirstOrDefaultAsync();
            if (likedPost != null)
            {
                likedPost.Liked = value;
                context.PostLikes.Update(likedPost);
                await context.SaveChangesAsync();
                return;
            }

            var post = await context.Posts.Where(x => x.Id == id).Include(u => u.User).Include(u => u.Likes).FirstOrDefaultAsync();
            var newLike = new PostLike
            {
                UserId = userId,
                PostId = id,
                Liked = value
            };
            post!.Likes!.Add(newLike);
            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }

        public async Task RemoveLike(int likeId)
        {
            var like = await context.PostLikes.FindAsync(likeId);
            if (like != null)
                context.PostLikes.Remove(like);

            await context.SaveChangesAsync();
        }
    }
}
