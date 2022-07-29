using GamersApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamersApp.DAL.ModelBuilder
{
    public class FriendBuilder : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.User1)
                .WithMany(x => x.Friends1)
                .HasForeignKey(pt => pt.UserID1)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder
                .HasOne(pt => pt.User2)
                .WithMany(t => t.Friends2)
                .HasForeignKey(pt => pt.UserID2);
        }
    }
}