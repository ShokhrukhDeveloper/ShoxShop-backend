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
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasMany<Comment>(m=>m.Comments)
            .WithOne(o=>o.User)
            .HasForeignKey(f=>f.UserId)
            .OnDelete(DeleteBehavior.SetNull);
            
        builder.Property(e=>e.Address)
            .HasColumnType("varchar(255)");
        builder.Property(e=>e.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired(false);

        builder.Property(e=>e.UserName)
            .HasColumnType("varchar(50)")
            .IsRequired(false);
            
        builder.Property(e=>e.Image)
            .HasColumnType("varchar(255)")
            .IsRequired(false);
            
        builder.Property(e=>e.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired(true);
            
        builder.Property(e=>e.PhoneNumber)
            .IsFixedLength(true)
            .HasMaxLength(13)
            .IsRequired(false);
            
        
    }
}