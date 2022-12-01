using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class LoginUserRepository : GenericRepository<LoginUser>, ILoginUserRepository
{
    public LoginUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}