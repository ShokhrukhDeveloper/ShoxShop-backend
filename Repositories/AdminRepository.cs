using ShoxShop.Data;
using ShoxShop.Entities;

namespace ShoxShop.Repositories;
public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(ApplicationDbContext context) : base(context)
    {}
}