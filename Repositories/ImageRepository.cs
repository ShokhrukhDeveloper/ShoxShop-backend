using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(ApplicationDbContext context) : base(context)
    {
    }
}