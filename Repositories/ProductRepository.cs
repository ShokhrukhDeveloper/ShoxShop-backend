using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}