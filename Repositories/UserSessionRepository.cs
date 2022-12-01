using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class UserSessionRepository : GenericRepository<UserSession>, IUserSessionReposritory
{
    public UserSessionRepository(ApplicationDbContext context) : base(context)
    {
    }
}