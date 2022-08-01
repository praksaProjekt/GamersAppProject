using GamersApp.DTO;
using GamersApp.Entities;

namespace GamersApp.AutoMappers
{
    public class PostMapper : AutoMapper.Profile
    {
        public PostMapper()
        {
            int CurrentUserId = 1;

            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Nickname, o => o.MapFrom(x => x.User.Nickname))
                .ForMember(x => x.Likes, o => o.MapFrom(x => x.Likes.Sum(v => v.Liked ? 1 : -1)))
                .ForMember(x => x.DidLike, o => o.MapFrom(x => x.Likes.First(u => u.UserId == CurrentUserId).Liked));
        }
    }
}
