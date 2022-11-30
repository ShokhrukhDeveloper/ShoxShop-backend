using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class VendorConfiguration : ConfigurationBase<Vendor>
{
    public override void Configure(EntityTypeBuilder<Vendor> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.VendorId);
        builder.Property(p=>p.VendorId).ValueGeneratedOnAdd();
        builder.HasMany(p=>p.VendorSessions)
            .WithOne(q=>q.Vendor)
            .HasForeignKey(k=>k.VendorId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}