using System.ComponentModel.DataAnnotations.Schema;

namespace GamersApp.Entities
{
    public class UserGame
    {
        public int Id { get; set; }

        public virtual User? User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Game")]
        public int? GameId { get; set; }

        public virtual Game? Game { get; set; }
        public string? GamerTag { get; set; }
    }
}
