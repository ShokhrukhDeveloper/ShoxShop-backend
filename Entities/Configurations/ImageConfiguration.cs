using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ShoxShop.Entities.Configurations;
class ImageConfiguration : ConfigurationBase<Image>
{
    public override void Configure(EntityTypeBuilder<Image> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.ImageId);
        builder.Property(p=>p.ImageId).
            HasColumnType("integer").
            ValueGeneratedOnAdd();
        builder.HasOne<Product>(p=>p.Product)
            .WithMany(p=>p.Images)
            .HasForeignKey(k=>k.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e=>e.ProductId).
            HasColumnType("integer").
            IsRequired(true);
        builder.Property(e=>e.ImageUrl).
            HasColumnType("varchar(255)").
            IsRequired(true);
        builder.Property(e=>e.Title).
            HasColumnType("varchar(50)").
            IsRequired(true);
        builder.Property(e=>e.Desription).
            HasColumnType("varchar(50)").
            IsRequired(false);
    }
}