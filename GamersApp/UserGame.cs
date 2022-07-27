using System.ComponentModel.DataAnnotations.Schema;

namespace GamersApp
{
    public class UserGame
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public string? GamerTag { get; set; }
    }
}
