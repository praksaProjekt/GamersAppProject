using GamersApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamersApp.DAL.ModelBuilder
{
    public class FriendRequestBuilder : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> modelBuilder)
        {
            modelBuilder
                   .HasOne(x => x.FollowerUser)
                   .WithMany(x => x.FriendRequestsMe)
                   .HasForeignKey(x => x.Follower)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                    .HasOne(x => x.FollowedUser)
                    .WithMany(x => x.FriendRequestsThem)
                    .HasForeignKey(x => x.Followed);

            //modelBuilder.HasIndex(p => new { p.Followed, p.Follower }).IsUnique();
        }
    }
}