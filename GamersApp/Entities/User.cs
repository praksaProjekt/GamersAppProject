namespace GamersApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.user;
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public int FailedPasswordAttempts { get; set; } = 0;
        public virtual ICollection<FriendRequest>? FriendRequestsMe {get; set;}
        public virtual ICollection<FriendRequest>? FriendRequestsThem { get; set; }
        public virtual ICollection<Friend>? Friends1 { get; set; }
        public virtual ICollection<Friend>? Friends2 { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
    }

    public enum Role
    {
        user,
        admin
    }
}
