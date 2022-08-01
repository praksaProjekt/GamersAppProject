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
        public string? FileURI { get; set; }
        public int Likes { get; set; } = 0;
        public DateTime? DatePublished { get; set; }
        public DateTime? DateEdited { get; set; }
        public bool IsEdited { get; set; } = false;
        public bool? DidLike { get; set; } = null;
        public int CommmentsNumber { get; set; }
    }
}
