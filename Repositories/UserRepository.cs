using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}