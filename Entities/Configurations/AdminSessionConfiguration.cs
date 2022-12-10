using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class VendorSessionConfiguration : ConfigurationBase<AdminSession>
{
    public override void Configure(EntityTypeBuilder<AdminSession> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.AdminSessionId);
        builder.Property(p=>p.AdminSessionId)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(e=>e.AccessToken)
            .IsRequired(true)
            .HasMaxLength(1024);
        builder.Property(e=>e.DeviceInfo)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");
        builder.Property(e=>e.IPAddress)
            .HasColumnType("varchar(20)");
        builder.Property(e=>e.RefreshToken)
            .HasColumnType("varchar(64)")
            .IsFixedLength(true);
        builder
            .HasOne(q=>q.Admin)
            .WithMany(m=>m.AdminSessions)
            .HasForeignKey(k=>k.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}