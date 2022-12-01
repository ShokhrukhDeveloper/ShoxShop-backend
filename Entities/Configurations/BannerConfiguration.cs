using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class BannerConfuguration :  ConfigurationBase<Banner>
{
    public override void Configure(EntityTypeBuilder<Banner> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.BannerId);
        builder.Property(p=>p.BannerId).ValueGeneratedOnAdd();
        builder.HasOne(p=>p.Admin)
            .WithMany(p=>p.Banners)
            .HasForeignKey(k=>k.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}