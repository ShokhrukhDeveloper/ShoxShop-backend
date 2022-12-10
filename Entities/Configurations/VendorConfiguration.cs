using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class VendorConfiguration : ConfigurationBase<Vendor>
{
    public override void Configure(EntityTypeBuilder<Vendor> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.VendorId);
        builder.Property(p=>p.VendorId)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.HasMany(p=>p.VendorSessions)
            .WithOne(q=>q.Vendor)
            .HasForeignKey(k=>k.VendorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(p=>p.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired(true);
        builder.Property(p=>p.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired(false);
        builder.Property(p=>p.Email)
            .HasColumnType("varchar(50)")
            .IsRequired(false);
        builder.Property(p=>p.Address)
            .HasColumnType("varchar(255)")
            .IsRequired(false);
        builder.Property(p=>p.Image)
            .HasColumnType("varchar(255)")
            .IsRequired(false);
        builder.Property(p=>p.MarketName)
            .HasColumnType("varchar(50)")
            .IsRequired(true);
        builder.Property(p=>p.VendorId)
            .HasColumnType("integer")
            .IsRequired(true);
        builder.Property(p=>p.Phone)
            .IsFixedLength(true)
            .HasMaxLength(13)
            .IsRequired(false);
    }
}