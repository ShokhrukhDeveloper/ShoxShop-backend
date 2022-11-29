using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class CommentConfiguration : ConfigurationBase<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.HasKey(c=>c.CommentId);
        builder.Property(c=>c.CommentId).ValueGeneratedOnAdd();
    }
    
}