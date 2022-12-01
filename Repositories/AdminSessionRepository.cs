using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class AdminSessionRepository : GenericRepository<AdminSession>, IAdminSessionRepository
{
    public AdminSessionRepository(ApplicationDbContext context) : base(context)
    {
    }
}