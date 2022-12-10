using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;

public class LikeConfiguration :  ConfigurationBase<Like>
{
    public override void Configure(EntityTypeBuilder<Like> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.LikeId);
        builder.Property(p=>p.LikeId).
            HasColumnType("integer").
            ValueGeneratedOnAdd();
        builder.Property(e=>e.ProductId).
            HasColumnType("integer").
            IsRequired(true);
        builder.HasOne<Product>(p=>p.Product)
            .WithMany(p=>p.Likes)
            .HasForeignKey(k=>k.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(e=>e.UserId).
            HasColumnName("integer").
            IsRequired(true);
        
    }
}