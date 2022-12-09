using ShoxShop.Const;
using ShoxShop.Dtos.Vendor;
using ShoxShop.Model;
using ShoxShop.Services.JWT;
using ShoxShop.UnitOfWork;
#pragma warning disable
namespace ShoxShop.Services.Vendor;
public partial class VendorService : IVendorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VendorService> _logger;
    private readonly IJWTService _jWTService;

    public VendorService(IUnitOfWork unitOfWork, ILogger<VendorService> logger,IJWTService jWTService)
    {
        _unitOfWork=unitOfWork;
        _logger=logger;
        _jWTService=jWTService;
    }
    public async ValueTask<Result<VendorModel>> CreateVendor(ulong AdminId,CreateVendorDto createVendor)
    {
        try
        {
            
            var loginCheck = _unitOfWork.LoginVendorRepository.Find(e=>e.PhoneNumber==createVendor.Phone).FirstOrDefault();
                if (loginCheck!=null)
                {
                    return new(false)
                    {
                        ErrorMessage="This Phone number already registred"
                    };
                }
            var vendor= await _unitOfWork.VendorRepository.AddAsync(
                new()
                {
                    LastName=createVendor.LastName,
                    FirstName=createVendor.FirstName,
                    Address=createVendor.Address,
                    DateOfBirth=createVendor.DateOfBirth,
                    AdminId=AdminId,
                    MarketName=createVendor.MarketName,
                    Phone=createVendor.Phone
                }
            );
            var login = _unitOfWork.LoginVendorRepository.AddAsync(
                new()
                {
                    Password=createVendor.Password,
                    PhoneNumber=createVendor.Phone,
                    PasswordHash=createVendor.Password,
                    VendorId=vendor.VendorId
                }
            );
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelVendor(vendor)
            };
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured at: {nameof(CreateVendor)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<VendorSessionModel>> DeleteVendorSession(ulong VendorId, ulong SesssionId)
    {
        try
        {
            var session= _unitOfWork.
                    VendorSessionRepository
                    .GetById(SesssionId);
            if (session is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                   ErrorMessage="Give Id Session not found" 
                };
            }
            if (session.VendorId!=VendorId)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Your access denied"
                };
            }
            var result= await _unitOfWork.VendorSessionRepository.Remove(session);
            return new(true)
            {
                Data=ToModelVendorSession(result)
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(DeleteVendorSession)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            }; 
            
        }
    }

    public async ValueTask<Result<List<VendorModel>>> GetAll(ushort Limit = 10, int Page = 1)
    {
        try
        {
            var count= _unitOfWork.VendorRepository.GetEntities.Count();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            var result= _unitOfWork
                    .VendorRepository
                    .GetEntities
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToList();
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=result.Select(ToModelVendor).ToList()  
            };
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured at: {nameof(GetAll)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            }; 
        }
    }

    public async ValueTask<Result<List<VendorSessionModel>>> GetAllVendorSession(ulong VendorId, ushort Limit=10,int Page=1)
    {
        try
        {
            var query=_unitOfWork
                    .VendorSessionRepository
                    .GetEntities
                    .Where(e=>e.VendorId==VendorId);
            var count = query.Count();
            var result= query.Skip((Page-1)*Limit)
                    .Take(Limit).ToList();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=result.Select(ToModelVendorSession).ToList(),
                PageCount=totalPage,
                CurrentPageIndex=Page
            };
                         
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured at: {nameof(GetAll)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<VendorModel>> GetVendorById(ulong Id)
    {
        try
        {
            var result = _unitOfWork
                    .VendorRepository
                    .GetById(Id);
            if (result is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given Id Vendor not found"
                };
            }
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelVendor(result)
            };
        }   
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured at: {nameof(GetVendorById)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<VendorSessionModel>> LoginVendor(string Phone,string Password)
    {
        try
        {
            var login = _unitOfWork
                    .LoginVendorRepository
                    .GetEntities
                    .FirstOrDefault(w=>w.PhoneNumber==Phone);
            if (login is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given phone number not found"
                };
            }
            if(login.Password!=Password)
            {
                return new(false)
                {
                    ErrorMessage="password inavliad"
                };
            }
            var token=new Const.JwtConst(){
                Id=login.VendorId,
                Role=Roles.Vendor,
                };
            var AccessToken= _jWTService.GenerateToken(token);
            var session= await _unitOfWork
                    .VendorSessionRepository
                    .AddAsync(
                        new()
                        {
                            VendorId=login.VendorId,
                            DeviceInfo="Adnad",
                            AccessToken=AccessToken,
                            RefreshToken="RefreshToken",
                            IPAddress="12.23.56.55",
                            Expires=DateTime.Now
                        }
                    );
            return new(true)
            {
                Data=ToModelVendorSession(session)
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(LoginVendor)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<VendorModel>>> Search(string SearchText,ushort Limit=10,int Page=1)
    {
        try
        {
            var query=_unitOfWork
                    .VendorRepository
                    .GetEntities
                    .Where(
                        t=>
                        t.FirstName.Contains(SearchText)
                        ||
                        t.LastName.Contains(SearchText)
                        );
            var count= query.Count();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            var result= query
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToList();
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=result.Select(ToModelVendor).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(Search)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
        
    }

    public async ValueTask<Result<VendorModel>> UpdateVendor(ulong VendorId,UpdateVendorDto createVendor)
    {
        try
        {
            var vendor= _unitOfWork.VendorRepository.GetById(VendorId);
            if(vendor is null)
            {
                return new(false)
                {
                    ErrorMessage="Vendor NotFound"
                };
                await _unitOfWork.RollbackAsync();
            }
             var result = await _unitOfWork.VendorRepository.AddAsync(
                new()
                {
                    LastName=createVendor.LastName,
                    FirstName=createVendor.FirstName,
                    Address=createVendor.Address,
                    DateOfBirth=createVendor.DateOfBirth,
                    MarketName=createVendor.MarketName,
                }
            );
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelVendor(result)
            };
            

           
        }
        catch (System.Exception e)
        {
           _logger.LogError($"Error occured at: {nameof(Search)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            }; 
        }
    }
}