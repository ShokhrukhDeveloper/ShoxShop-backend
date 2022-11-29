using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoxShop.Entities.Configurations;
public class FavoirateConfiguration : ConfigurationBase<Favoirate>
{
    public override void Configure(EntityTypeBuilder<Favoirate> builder)
    {
        base.Configure(builder);
        builder.HasKey(k=>k.FavoirateId);
        
    }
}