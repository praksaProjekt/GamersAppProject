using GamersApp.DAL.ModelBuilder;
using GamersApp.Entities;

namespace GamersApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FriendRequestBuilder().Configure(modelBuilder.Entity<FriendRequest>());
            new FriendBuilder().Configure(modelBuilder.Entity<Friend>());
        }
    }
}
