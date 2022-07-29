namespace GamersApp.Entities
{
    public class FriendRequest
    {
        public  int Id { get; set; }
        public  int Follower { get; set; }
        public virtual User FollowerUser { get; set; }
        public int Followed { get; set; }
        public virtual User FollowedUser { get; set; }
    }
}
