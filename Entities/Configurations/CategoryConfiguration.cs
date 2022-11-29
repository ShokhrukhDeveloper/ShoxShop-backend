using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class CategoryConfiguration : ConfigurationBase<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.CategoryId);
        builder.Property(x=>x.CategoryId)
            .ValueGeneratedOnAdd();
        builder.HasMany<Product>(p=>p.Products)
            .WithOne(s=>s.Category)
            .HasForeignKey(s=>s.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<SubCategory>(c=>c.SubCategories)
            .WithOne(s=>s.Category)
            .HasForeignKey(k=>k.CetegoryId)
            .OnDelete(DeleteBehavior.Cascade);
        

    }
}