namespace ShoxShop.UnitOfWork;

using System.Threading.Tasks;
using ShoxShop.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public IAdminRepository Admins => throw new NotImplementedException();

    public ICategoryRepository AdminCategory => throw new NotImplementedException();

    public ICommentRepository CommentRepository => throw new NotImplementedException();

    public IFavoirateRepository FavoirateRepository => throw new NotImplementedException();

    public IImageRepository ImageRepository => throw new NotImplementedException();

    public ILikeRepository LikeRepository => throw new NotImplementedException();

    public ILocationRepository LocationRepository => throw new NotImplementedException();

    public ILoginAdminRepository LoginAdminRepository => throw new NotImplementedException();

    public ILoginUserRepository LoginUserRepository => throw new NotImplementedException();

    public ILoginVendorRepository LoginVendorRepository => throw new NotImplementedException();

    public IProductRepository ProductRepository => throw new NotImplementedException();

    public ISubCategoryRepository SubCategoryRepository => throw new NotImplementedException();

    public IUserRepository UserRepository => throw new NotImplementedException();

    public IUserSessionReposritory UserSessionReposritory => throw new NotImplementedException();

    public IVendorRepository VendorRepository => throw new NotImplementedException();

    public IVendorSessionReposiroy VendorSessionReposiroy => throw new NotImplementedException();

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public async Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }

    public async Task RollbackAsync()
    {
        throw new NotImplementedException();
    }
}