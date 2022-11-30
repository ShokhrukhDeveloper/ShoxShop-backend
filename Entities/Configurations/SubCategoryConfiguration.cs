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
        
    }
}