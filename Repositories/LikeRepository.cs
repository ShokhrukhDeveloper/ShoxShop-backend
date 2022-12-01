using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(ApplicationDbContext context) : base(context)
    {
    }
}