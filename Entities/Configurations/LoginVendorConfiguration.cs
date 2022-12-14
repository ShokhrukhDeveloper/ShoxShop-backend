using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class LoginVendorConfiguration : ConfigurationBase<LoginVendor>
{
    public override void Configure(EntityTypeBuilder<LoginVendor> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.Id);
        builder.Property(p=>p.Id).ValueGeneratedOnAdd();
        builder.HasOne<Vendor>(p=>p.Vendor)
            .WithOne(p=>p.LoginVendor)
            .HasForeignKey<LoginVendor>(k=>k.VendorId)
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