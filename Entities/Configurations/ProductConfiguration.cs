using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class ProductConfiguration : ConfigurationBase<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.ProductId);
        builder.Property(p=>p.ProductId).ValueGeneratedOnAdd();
        // builder.HasMany<Like>(p=>p.Likes)
        //     .WithOne(p=>p.Product)
        //     .HasForeignKey(k=>k.ProductId)
        //     .OnDelete(DeleteBehavior.Cascade);
        
    }
}