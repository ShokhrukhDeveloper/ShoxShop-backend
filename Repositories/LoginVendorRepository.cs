using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class LoginVendorRepository : GenericRepository<LoginVendor>, ILoginVendorRepository
{
    public LoginVendorRepository(ApplicationDbContext context) : base(context)
    {
    }
}