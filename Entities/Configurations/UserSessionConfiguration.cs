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
        
        
    }
}