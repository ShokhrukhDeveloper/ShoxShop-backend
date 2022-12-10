using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class FavoirateConfiguration : ConfigurationBase<Favoirate>
{
    public override void Configure(EntityTypeBuilder<Favoirate> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.FavoirateId);
        builder.Property(p=>p.FavoirateId).
            ValueGeneratedOnAdd();
        builder.Property(r=>r.ProductId)
            .HasColumnType("integer")
            .IsRequired(true);
        builder.Property(r=>r.UserId)
            .HasColumnType("integer")
            .IsRequired(true);
        builder.HasOne(o=>o.User)
            .WithMany(u=>u.Favoirates)
            .HasForeignKey(k=>k.UserId);
        
    }
}