namespace ShoxShop.UnitOfWork;

using System.Threading.Tasks;
using ShoxShop.Data;
using ShoxShop.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext=dbContext;
    }
    private IAdminRepository? _AdminRepository ;
    private ICategoryRepository? _CategoryRepository;
    private ICommentRepository? _CommentRepository;
    private IAdminSessionRepository? _AdminSessionRepository;
    private IFavoirateRepository? _FavoirateRepository;
    private IImageRepository? _ImageRepository;
    private ILikeRepository? _LikeRepository;
    private ILocationRepository? _LocationRepository;
    private ILoginAdminRepository? _LoginAdminRepository;
    private ILoginUserRepository? _LoginUserRepository;
    private ILoginVendorRepository? _LoginVendorRepository;
    private IProductRepository? _ProductRepository;
    private ISubCategoryRepository? _SubCategoryRepository;
    private IUserRepository? _UserRepository;
    private IUserSessionReposritory? _UserSessionReposritory;
    private IVendorRepository? _VendorRepository;
    private IVendorSessionRepository? _VendorSessionRepository;
    //
    //
    //
    public IAdminRepository AdminRepository =>_AdminRepository??=new AdminRepository(_dbContext);
            
        

    public ICategoryRepository CategoryRepository => _CategoryRepository??= new CategoryRepository(_dbContext);

    public ICommentRepository CommentRepository =>_CommentRepository??= new CommentRepository(_dbContext);

    public IFavoirateRepository FavoirateRepository => _FavoirateRepository??= new FavoirateRepository(_dbContext);

    public IImageRepository ImageRepository => _ImageRepository ??= new ImageRepository(_dbContext);

    public ILikeRepository LikeRepository => _LikeRepository ??= new LikeRepository(_dbContext);

    public ILocationRepository LocationRepository => _LocationRepository ??= new LocationRepository(_dbContext);

    public ILoginAdminRepository LoginAdminRepository => _LoginAdminRepository ??= new LoginAdminRepository(_dbContext);

    public ILoginUserRepository LoginUserRepository => _LoginUserRepository ??= new LoginUserRepository(_dbContext);

    public ILoginVendorRepository LoginVendorRepository => _LoginVendorRepository ??= new LoginVendorRepository(_dbContext);

    public IProductRepository ProductRepository => _ProductRepository ??= new ProductRepository(_dbContext);

    public ISubCategoryRepository SubCategoryRepository => _SubCategoryRepository ??= new SubCategoryRepository(_dbContext);

    public IUserRepository UserRepository => _UserRepository ??= new UserRepository(_dbContext);

    public IUserSessionReposritory UserSessionReposritory => _UserSessionReposritory ??= new UserSessionRepository(_dbContext);

    public IVendorRepository VendorRepository => _VendorRepository ??= new VendorRepository(_dbContext);

    public IVendorSessionRepository VendorSessionRepository => _VendorSessionRepository ??= new VendorSessionRepository(_dbContext);

    public IAdminSessionRepository AdminSessionRepository => _AdminSessionRepository ??= new AdminSessionRepository(_dbContext);

    
    
    public void Commit()
        =>_dbContext.SaveChanges();
    

    public async  Task CommitAsync()
        => await _dbContext.SaveChangesAsync();

    public void Rollback()
    {
       _dbContext.Dispose();
       GC.SuppressFinalize(this);
    } 

    public async Task RollbackAsync()
    {
        await _dbContext.DisposeAsync();
        GC.SuppressFinalize(this);

    } 
}