using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}