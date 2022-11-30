namespace ShoxShop.UnitOfWork;
using ShoxShop.Repositories;
public interface IUnitOfWork
{
    IAdminRepository Admins { get;}
    ICategoryRepository AdminCategory { get;}
    ICommentRepository CommentRepository { get;}
    IFavoirateRepository FavoirateRepository { get;}
    IImageRepository ImageRepository { get;}
    ILikeRepository LikeRepository { get;}
    ILocationRepository LocationRepository { get;}
    ILoginAdminRepository LoginAdminRepository { get;}
    ILoginUserRepository LoginUserRepository { get;}
    ILoginVendorRepository LoginVendorRepository {get;}
    IProductRepository ProductRepository {get;}
    ISubCategoryRepository SubCategoryRepository {get;}
    IUserRepository UserRepository {get;}
    IUserSessionReposritory UserSessionReposritory {get;}
    IVendorRepository VendorRepository {get;}
    IVendorSessionReposiroy VendorSessionReposiroy {get;}
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}