using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace ShoxShop.Entities.Configurations;
public class AdminConfiguration : ConfigurationBase<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.AdminId);
        builder.HasMany<Vendor>(v=>v.Vendors)
            .WithOne(o=>o.Admin)
            .HasForeignKey(f=>f.AdminId);
    }
}