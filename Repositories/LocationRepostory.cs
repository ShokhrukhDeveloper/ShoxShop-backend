using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext context) : base(context)
    {
    }
}