using System.ComponentModel.DataAnnotations.Schema;

namespace GamersApp
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }=string.Empty;
    }
}

