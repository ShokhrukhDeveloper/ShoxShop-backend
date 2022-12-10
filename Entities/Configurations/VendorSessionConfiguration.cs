using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class AdminSessionConfiguration : ConfigurationBase<VendorSession>
{
    public override void Configure(EntityTypeBuilder<VendorSession> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.VendorSessionId);
        builder.Property(p=>p.VendorSessionId).ValueGeneratedOnAdd();
        builder.HasOne(q=>q.Vendor)
            .WithMany(m=>m.VendorSessions)
            .HasForeignKey(k=>k.VendorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e=>e.AccessToken)
            .IsRequired(true)
            .HasMaxLength(1024);
        builder.Property(e=>e.DeviceInfo)
            .HasColumnType("varchar(50)");
        builder.Property(e=>e.IPAddress)
            .HasColumnType("varchar(20)");
        builder.Property(e=>e.RefreshToken)
            .HasColumnType("varchar(64)")
            .IsFixedLength(true);
        
    }
}