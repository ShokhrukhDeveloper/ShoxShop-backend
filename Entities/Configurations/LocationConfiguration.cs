using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class LocationConfiguration : ConfigurationBase<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.LocationId);
        builder.Property(p=>p.LocationId).ValueGeneratedOnAdd();
        builder.HasOne<User>(s=>s.User)
            .WithOne(a=>a.Location)
            .HasForeignKey<Location>(k=>k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}