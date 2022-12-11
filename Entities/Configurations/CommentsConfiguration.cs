using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class CommentConfiguration : ConfigurationBase<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.HasKey(c=>c.CommentId);

        // builder.Property(c=>c.CommentId).
        //     HasColumnType("integer").
        //     ValueGeneratedOnAdd();
        // builder.HasOne(p=>p.Product)
        //         .WithMany(e=>e.Comments)
        //         .HasForeignKey(e=>e.ProductId)
        //         .OnDelete(DeleteBehavior.Cascade);

        // builder.HasOne(p=>p.User)
        //         .WithMany(e=>e.Comments)
        //         .OnDelete(DeleteBehavior.Cascade);

        // builder.Property(c=>c.ProductId).
        //     IsRequired(true);

        // builder.Property(c=>c.UserId).
        //     IsRequired(true);

        builder.Property(c=>c.Title).
            HasColumnType("varchar(50)");

        builder.Property(c=>c.Message).
            HasColumnType("varchar(255)")
            .IsRequired(true);
    }
    
}