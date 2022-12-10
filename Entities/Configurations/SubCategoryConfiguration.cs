using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class SubCategoryConfiguration:ConfigurationBase<SubCategory>
{
    public override void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.SubCategoryId);
        builder.Property(p=>p.SubCategoryId).ValueGeneratedOnAdd();
        builder.HasMany(p=>p.Products)
            .WithOne(q=>q.SubCategory)
            .HasForeignKey(k=>k.SubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e=>e.CetegoryId)
            .HasColumnType("integer")
            .IsRequired(true);
        
        builder.Property(e=>e.Name)
            .HasColumnType("varchar(50)")
            .IsRequired(true);
        
        builder.Property(e=>e.Description)
            .HasColumnType("varchar(50)")
            .IsRequired(false);
        builder.Property(e=>e.Image)
            .HasColumnType("varchar(255)")
            .IsRequired(true);
        
    }
}