using GamersApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamersApp.DAL.ModelBuilder
{
    public class PostBuilder : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.User)
                .WithMany(User => User.Posts)
                .HasForeignKey(x => x.UserId);

        }
    }
}