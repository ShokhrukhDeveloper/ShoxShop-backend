using Microsoft.EntityFrameworkCore;
using ShoxShop.Const;
using ShoxShop.Dtos.Admin;
using ShoxShop.Dtos.User;
using ShoxShop.Entities;
using ShoxShop.Model;
using ShoxShop.Services.File;
using ShoxShop.Services.JWT;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.UserService;
public partial class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;
    private readonly IJWTService _jWTService;

    public UserService(IUnitOfWork unitOfWork,ILogger<UserService> logger,IJWTService jWTService)
    {
        _unitOfWork=unitOfWork;
        _logger=logger;
        _jWTService=jWTService;
    }
    public async ValueTask<Result<ProductModel>> CreateFavoirateByUserId(ulong UserId, ulong ProductId)
    {
        try
        {
            var Exists= _unitOfWork.FavoirateRepository.Find(e=>e.ProductId==ProductId&&UserId==e.UserId).FirstOrDefault();
            if (Exists is not null)
            {
                return new(false)
                {
                    ErrorMessage="This product already added favoirates to your account"
                };
            }
            var product= _unitOfWork.ProductRepository
                    .GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id Product not found"
                };
            }
            var user= _unitOfWork.UserRepository.GetById(UserId);
            if (user is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id User not found"
                };
            }
            Favoirate favoir=new()
            {
                ProductId=ProductId,
                UserId=UserId
            };

            var favoirate= await _unitOfWork.FavoirateRepository.AddAsync(favoir);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToProductModel(product)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateFavoirateByUserId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<UserModel>> CreateUser(CreateUserDto dto)
    {
        try
        {
            
            
            var Exists= _unitOfWork.UserRepository.Find(e=>e.PhoneNumber==dto.Phone).FirstOrDefault();
            if (Exists is not null)
            {
                return new(false)
                {
                    ErrorMessage="this Phone Number registred please change another "
                };
            }
            string? imagePath=null;
            if (dto.Image is not null)
            {
                FileService fileService=new FileService();
                imagePath= await fileService.SaveFile(dto.Image,FileConst.UserImages);
            }
            User user=new()
            {
                FirstName=dto.FirstName,
                PhoneNumber=dto.Phone!,
                LastName=dto.LastName??"",
                DateOfBirth=dto.DateOfBirth,
                UserName=dto.UserName??"",
                Address=dto.Address,
                Image=imagePath,
                
            };
            var result = await _unitOfWork.UserRepository.AddAsync(user);
                        LoginUser login=new()
            {
                UserId=result.UserId,
                Password=dto.Password!,
                PasswordHash=dto.Password!,
                Phone=user.PhoneNumber
            };
            await _unitOfWork.LoginUserRepository.AddAsync(login);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToUserModel(user)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateUser)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<bool>> DeleteFavoirateById(ulong FavoirateId, ulong UserId)
    {
        try
        {
            var Exists= _unitOfWork.FavoirateRepository.Find(e=>e.FavoirateId==FavoirateId&&UserId==e.UserId).FirstOrDefault();
            if (Exists is null)
            {
                return new(false)
                {
                    ErrorMessage="Given favoirate Id not found"
                };
            }
            var result= await _unitOfWork.FavoirateRepository.Remove(Exists);

            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=true
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateFavoirateByUserId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<UserSessionModel>> DeleteUserSession(ulong UserId, ulong SessionId)
    {
        try
        {
            var result= _unitOfWork.UserSessionReposritory.Find(w=>w.UserId==UserId&&w.UserSessionId==SessionId).FirstOrDefault();
            if (result is null)
            {
                return new(false)
                {
                    ErrorMessage="User session not found"
                };
            }
            var session=await _unitOfWork.UserSessionReposritory.Remove(result);
            return new(true)
            {
                Data=ToUserSessionModel(session)
            };
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public async ValueTask<Result<List<ProductModel>>> GetFavoiratesByUserId(ulong UserId, ushort Limit = 10, int Page = 10)
    {
        try
        {
            var Exists= _unitOfWork.FavoirateRepository.Find(e=>UserId==e.UserId);
            if (Exists is null)
            {
                return new(false)
                {
                    ErrorMessage="Given favoirate Id not found"
                };
            }
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=new()
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateFavoirateByUserId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<UserModel>> GetUserDataByUserId(ulong UserId)
    {
        try
        {
            var user= _unitOfWork.UserRepository.GetById(UserId);
            if (user is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id User not found"
                };
            }
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToUserModel(user)
            };
        }
        catch (System.Exception e)
        {
        _logger.LogError($"Error occured at: {nameof(GetUserDataByUserId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<UserSessionModel>>> GetUserSessionByUserId(ulong UserId,ushort Limit=10,int Page=10)
    {
        try
        {
            var query = _unitOfWork
                    .UserSessionReposritory
                    .GetEntities
                    .Where(s=>s.UserId==UserId);
            var count=query.Count();
            var result=await query.
                    Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToListAsync();
            var totalPage=(int)Math.Ceiling(count/(double)Limit);    
            
            await _unitOfWork.RollbackAsync();
            var data=result.Select(e=>ToUserSessionModel(e)).ToList();
            return new(true)
            {
                PageCount=totalPage,
                CurrentPageIndex=Page,
                Data=data
            };
        }
        catch (System.Exception e)
        {
        _logger.LogError($"Error occured at: {nameof(GetUserDataByUserId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }   
    }

    public async ValueTask<Result<UserSessionModel>> LoginUser(LoginDto userLogin)
    {
    try
    {
        var user= await _unitOfWork
                .LoginUserRepository
                .GetEntities
                .FirstOrDefaultAsync(o=>o.Phone==userLogin.Phone);
        if (user is null)
        {
            return new(false)
            {
                ErrorMessage="Login not Found"
            };
        } 
        if (user.Password!=userLogin.Password)
        {
            return new(false)
            {
                ErrorMessage="Phone or password invalid"
            };
        }
        string AccessToken=_jWTService.GenerateToken(new()
        {
            Id=user.Id,
            Role=Roles.User
        })!;
        UserSession session=new()
        {
            UserId=user.UserId,
            DeviceInfo="Android",
            AccessToken=AccessToken,
            RefreshToken="RefreshToken",
            IPAddress=" . . . ",
            Expires=DateTime.Now.AddDays(10)
        };
        var result= await _unitOfWork.UserSessionReposritory.AddAsync(session);
        await _unitOfWork.RollbackAsync();
        return new(true)
        {
            Data=ToUserSessionModel(result)
        };
    }
    catch (System.Exception e)
    {
     _logger.LogError($"Error occured at: {nameof(LoginUser)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
    }
    }
}