using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class CommentConfiguration : ConfigurationBase<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.HasKey(c=>c.CommentId);
        builder.Property(c=>c.CommentId).
            HasColumnType("integer").
            ValueGeneratedOnAdd();
        builder.Property(c=>c.UserId).
            HasColumnType("integer")
            .IsRequired();
        builder.Property(c=>c.ProductId).
            HasColumnType("integer")
            .IsRequired();
        builder.Property(c=>c.Title).
            HasColumnType("varchar(50)");
        builder.Property(c=>c.Message).
            HasColumnType("varchar(255)");
    }
    
}