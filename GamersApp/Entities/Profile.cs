using System.ComponentModel.DataAnnotations;

namespace GamersApp.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? EpicGames { get; set; }
        public string? Steam { get; set; }
        public string? ProfilePictureURI { get; set; }
        public string? Video { get; set; }
    }
}
