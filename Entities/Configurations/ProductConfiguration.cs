using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class ProductConfiguration : ConfigurationBase<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.ProductId);
        builder.Property(p=>p.ProductId)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(e=>e.CoverImage)
            .HasColumnType("varchar(255)")
            .IsRequired(true);
        builder.Property(e=>e.Name)
            .HasColumnType("varchar(50)")
            .IsRequired(true);
        builder.Property(e=>e.Description)
            .IsRequired(false);
        builder.Property(e=>e.Model)
            .HasColumnType("varchar(50)");
        builder.Property(e=>e.SubCategoryId)
            .HasColumnType("integer")
            .IsRequired(true);
        builder.Property(e=>e.CategoryId)
            .HasColumnType("integer")
            .IsRequired(true);
        builder.Property(e=>e.VendorId)
            .HasColumnType("integer")
            .IsRequired(true);
        
        
        
    }
}