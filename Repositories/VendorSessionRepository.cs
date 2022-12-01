using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class VendorSessionRepository : GenericRepository<VendorSession>, IVendorSessionRepository
{
    public VendorSessionRepository(ApplicationDbContext context) : base(context)
    {
    }
}