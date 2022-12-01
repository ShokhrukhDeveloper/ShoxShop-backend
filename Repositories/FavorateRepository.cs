using ShoxShop.Data;
using ShoxShop.Entities;

namespace ShoxShop.Repositories;
public class FavoirateRepository : GenericRepository<Favoirate>, IFavoirateRepository
{
    public FavoirateRepository(ApplicationDbContext context) : base(context)
    {
    }
}