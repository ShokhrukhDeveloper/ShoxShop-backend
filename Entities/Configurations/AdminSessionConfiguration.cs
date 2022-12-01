using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class VendorSessionConfiguration : ConfigurationBase<AdminSession>
{
    public override void Configure(EntityTypeBuilder<AdminSession> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.AdminSessionId);
        builder.Property(p=>p.AdminSessionId).ValueGeneratedOnAdd();
        builder
            .HasOne(q=>q.Admin)
            .WithMany(m=>m.AdminSessions)
            .HasForeignKey(k=>k.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}