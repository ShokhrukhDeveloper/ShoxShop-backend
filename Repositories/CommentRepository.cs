using ShoxShop.Data;
using ShoxShop.Entities;
namespace ShoxShop.Repositories;
public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {}
}