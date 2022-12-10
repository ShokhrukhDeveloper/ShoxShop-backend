using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;

public class LoginAdminConfiguration :   ConfigurationBase<LoginAdmin>
{
    public override void Configure(EntityTypeBuilder<LoginAdmin> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.Id);
        builder.Property(p=>p.Id).
            HasColumnName("integer").
            ValueGeneratedOnAdd();
        builder.HasOne<Admin>(p=>p.Admin)
            .WithOne(p=>p.AdminLogin).HasForeignKey<LoginAdmin>(k=>k.AdminId)
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