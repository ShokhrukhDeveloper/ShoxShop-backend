using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class LoginAdminRepository : GenericRepository<LoginAdmin>, ILoginAdminRepository
{
    public LoginAdminRepository(ApplicationDbContext context) : base(context)
    {
    }
}