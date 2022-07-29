using GamersApp.DAL.ModelBuilder;
using GamersApp.Entities;

namespace GamersApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                 .HasOne(x => x.User1)
                 .WithMany(x => x.Friends1) // <--
                 .HasForeignKey(pt => pt.UserID1)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(pt => pt.User2)
                .WithMany(t => t.Friends2)
                .HasForeignKey(pt => pt.UserID2);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.User)
                .WithMany(User => User.Posts)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<PostLike>()
                .HasOne(x => x.Post)
                .WithMany(p => p.Likes).
                HasForeignKey(x => x.PostId);
                
            new FriendRequestBuilder().Configure(modelBuilder.Entity<FriendRequest>());
            new FriendBuilder().Configure(modelBuilder.Entity<Friend>());


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<PostLike> PostLikes { get; set; }
    }

 
}
