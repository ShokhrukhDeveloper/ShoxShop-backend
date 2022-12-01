using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
{
    public VendorRepository(ApplicationDbContext context) : base(context)
    {
    }
}