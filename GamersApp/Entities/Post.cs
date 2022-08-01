using System.ComponentModel.DataAnnotations;

namespace GamersApp.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public string? fileURI { get; set; }
        public PostType PostType { get; set; } = PostType.none;
        public DateTime? DatePublished { get; set; }
        public DateTime? DateEdited { get; set; }
        public bool IsEdited { get; set; } = false; 
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<PostLike>? Likes { get; set; }
    }

    public enum PostType
    {
        none,
        photo,
        video
    }
}
