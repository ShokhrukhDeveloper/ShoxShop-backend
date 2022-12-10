using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class BannerConfuguration :  ConfigurationBase<Banner>
{
    public override void Configure(EntityTypeBuilder<Banner> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.BannerId);
        builder.Property(p=>p.BannerId).
            HasColumnType("integer").
            ValueGeneratedOnAdd();
        builder.Property(p=>p.AdminId).
            HasColumnType("integer");
        builder.Property(e=>e.Description)
            .HasColumnType("varchar(255)");
        builder.Property(e=>e.Title)
            .HasColumnType("varchar(50)");
        builder.HasOne(p=>p.Admin)
            .WithMany(p=>p.Banners)
            .HasForeignKey(k=>k.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}