using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}