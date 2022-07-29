using GamersApp.Entities;

namespace GamersApp.DTO
{
    public class PostViewModel
    {
        public int Id { get; set; } 
        public string Body { get; set; } = String.Empty;
        public string Nickname  { get; set; } = string.Empty;
        public int? UserId{ get; set; }
        public PostType PostType { get; set; } = PostType.none;
        public string? fileURI { get; set; }
        public int Likes { get; set; } = 0;

    }
}
