using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace ShoxShop.Entities.Configurations;
public class AdminConfiguration : ConfigurationBase<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.AdminId);
        builder.Property(b=>b.AdminId)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(e=>e.Image).HasMaxLength(255);
        builder.Property(e=>e.FirstName).HasMaxLength(50);
        builder.Property(e=>e.LastName).HasMaxLength(50);
        builder.Property(e=>e.PhoneNumber).HasMaxLength(13);
        builder.HasMany<Vendor>(v=>v.Vendors)
            .WithOne(o=>o.Admin)
            .HasForeignKey(f=>f.AdminId);
    }
}