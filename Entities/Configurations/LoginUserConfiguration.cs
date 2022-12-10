using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class LoginUserConfiguration :   ConfigurationBase<LoginUser>
{
    public override void Configure(EntityTypeBuilder<LoginUser> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.Id);
        builder.Property(p=>p.Id).ValueGeneratedOnAdd();
        builder.HasOne<User>(p=>p.User)
            .WithOne(p=>p.LoginUser).HasForeignKey<LoginUser>(k=>k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
          builder.Property(e=>e.Phone).
            IsFixedLength(true).
            HasMaxLength(13);
        builder.Property(e=>e.PasswordHash).
            IsFixedLength(true).
            HasMaxLength(64);
        builder.Property(p=>p.Id).
            HasColumnName("integer")
            .IsRequired(true);
    }
}