using System.ComponentModel.DataAnnotations.Schema;

namespace GamersApp.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; } = string.Empty;
    }
}

