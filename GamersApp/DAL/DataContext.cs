﻿using GamersApp.DAL.ModelBuilder;
using GamersApp.Entities;

namespace GamersApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PostBuilder().Configure(modelBuilder.Entity<Post>());
            new PostLikeBuilder().Configure(modelBuilder.Entity<PostLike>());
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
