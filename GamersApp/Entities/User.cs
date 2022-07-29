using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GamersApp.Entities
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public Role role { get; set; } = Role.user;
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public int FailedPasswordAttempts { get; set; } = 0;
        public virtual ICollection<FriendRequest>? FriendRequestsMe {get; set;}
        public virtual ICollection<FriendRequest>? FriendRequestsThem { get; set; }


    }

    public enum Role
    {
        user,
        admin
    }
}
