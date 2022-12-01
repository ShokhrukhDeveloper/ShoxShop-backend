namespace ShoxShop.UnitOfWork;
using ShoxShop.Repositories;
public interface IUnitOfWork
{
    IAdminRepository AdminRepository { get;}
    IAdminSessionRepository AdminSessionRepository { get;}
    ICategoryRepository CategoryRepository { get;}
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
    IVendorSessionRepository VendorSessionRepository {get;}
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}