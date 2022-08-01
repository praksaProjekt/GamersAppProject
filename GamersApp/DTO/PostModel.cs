using GamersApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace GamersApp.DTO
{
    public class PostModel
    {
        [Required]
        public int UserId { get; set; }
        public PostType PostType { get; set; } = PostType.none;
        public string Body { get; set; } = string.Empty;
        public string Filename { get; set; } = string.Empty;
        public string FileBase64 { get; set; } = string.Empty;
    }
}
