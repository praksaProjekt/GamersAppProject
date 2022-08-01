using GamersApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamersApp.DAL.ModelBuilder
{
    public class PostLikeBuilder : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.Post)
                .WithMany(p => p.Likes).
                HasForeignKey(x => x.PostId);
        }
    }
}