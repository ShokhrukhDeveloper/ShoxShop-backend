using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class UserSessionConfiguration : ConfigurationBase<UserSession>
{
    public override void Configure(EntityTypeBuilder<UserSession> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.UserSessionId);
        builder.Property(p=>p.UserSessionId).ValueGeneratedOnAdd();
        builder.HasOne(q=>q.User)
            .WithMany(m=>m.UserSessions)
            .HasForeignKey(k=>k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(e=>e.AccessToken)
            .IsUnicode(true)
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