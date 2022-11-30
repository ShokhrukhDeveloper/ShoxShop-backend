using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class UserConfiguration : ConfigurationBase<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.UserId);
        builder.Property(p=>p.UserId).ValueGeneratedOnAdd();
        builder.HasMany(p=>p.UserSessions)
            .WithOne(q=>q.User)
            .HasForeignKey(k=>k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<Favoirate>(m=>m.Favoirates)
            .WithOne(o=>o.User)
            .HasForeignKey(f=>f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}