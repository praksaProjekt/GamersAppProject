using System.ComponentModel.DataAnnotations;

namespace GamersApp.Entities
{
    public class PostLike
    {
        [Key]
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; }
        public int PostId { get; set; }     
        public Post Post { get; set; }
        public bool Liked { get; set; } 

    }
}
