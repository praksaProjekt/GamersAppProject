using System.ComponentModel.DataAnnotations.Schema;

namespace GamersApp
{
    public class Game
    {
        public int Id { get; set; }
        public Games GameName { get; set; }
    }
    public enum Games
    {
        LeagueOflegends,
        ModernWarfare,
        RocketLeague,
        ApexLegends,
        Fortnite,
        Valorant
    }
}

