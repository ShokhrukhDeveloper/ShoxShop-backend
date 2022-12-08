using Microsoft.EntityFrameworkCore;
using ShoxShop.Const;
using ShoxShop.Dtos.Admin;
using ShoxShop.Entities;
using ShoxShop.Model;
using ShoxShop.Services.JWT;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Admin;
public partial class AdminService : IAdminService
{
    private readonly IJWTService _jWTService;
    private readonly IUnitOfWork _unitOFWork;
    private readonly ILogger<AdminService> _logger;

    public AdminService(IUnitOfWork unitOFWork,ILogger<AdminService> logger,IJWTService jWTService)
    {
        _jWTService=jWTService;
        _unitOFWork=unitOFWork;
        _logger=logger;
    }
    public async ValueTask CreateAdmin(AdminCreateDto adminCreateDto)
    {
        var result=await _unitOFWork.AdminRepository.AddAsync(
            new (){
                        FirstName=adminCreateDto.FirstName,
                        LastName=adminCreateDto.LastName,
                        BirthDate=adminCreateDto.BirthDate,
                        PhoneNumber=adminCreateDto.PhoneNumber,
                        Image=adminCreateDto.Image
                    }
            );
    }

    public async ValueTask<Result<AdminSessionModel>> DeleteAdminSession(ulong AdminId, ulong AdminSessionId)
    {
           
        try
        {
            var result = await _unitOFWork
                    .AdminSessionRepository
                    .GetEntities
                    .FirstOrDefaultAsync(r=>r.AdminSessionId==AdminSessionId&&r.AdminId==AdminId);
            if (result is null)
            {
                return new(false)
                    {
                        ErrorMessage="Admin session or session admin not found"
                    };
            }
            var deletedSession= await _unitOFWork
                    .AdminSessionRepository
                    .Remove(result);
            await _unitOFWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelSession(deletedSession)
            };
        }
        catch (System.Exception e)
        {
             _logger.LogError($"Error occured at{nameof(DeleteAdminSession)} Error Message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occured server please contact support "
            };
        }
    }

    public async ValueTask<Result<AdminModel>> GetAdminData(ulong AdminId)
    {
        try
        {
            var admin= _unitOFWork.AdminRepository.GetById(AdminId);
            await _unitOFWork.RollbackAsync();
            if (admin is null)
            {
                return new(false)
                    {
                        ErrorMessage="Admin data not found"
                    };
            }
            return new(true)
                {
                    Data=ToModelAdmin(admin)
                };
            

        }
        catch (System.Exception e)
        {
             _logger.LogError($"Error occured at{nameof(GetAdminData)} Error Message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occured server please contact support "
            };
        }
    }

    public async ValueTask<Result<List<AdminSessionModel>>> GetAllAdminSession(ulong AdminId, ushort Limit, int Page)
    {
        try
        {
            var query= _unitOFWork
                    .AdminSessionRepository
                    .Find(e=>e.AdminId==AdminId);
            var count=query.Count();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            var session=query
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToList();
            await _unitOFWork.RollbackAsync();
            return new(true)
            {
                Data=session.Select(ToModelSession).ToList(),
                PageCount=totalPage,
                CurrentPageIndex=Page
            };
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured at: {nameof(GetAllAdminSession)} Error Message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occured server please contact support "
            };
        }
    }

    public async ValueTask<Result<AdminSessionModel>> LoginAdmin(string PhoneNumber, string Password,HttpContext context)
    {
        try
        {
            var result=await _unitOFWork.LoginAdminRepository.GetEntities.FirstOrDefaultAsync(e=>e.Phone==PhoneNumber&&e.Password==Password);
             if (result is null)
             {
                return new(false)
                {
                    ErrorMessage="Password or Phone number invalid",
                };
             }
             var admin= _unitOFWork.AdminRepository.GetById(result.AdminId);
             if (admin is null)
             {
                return new(false)
                {
                    ErrorMessage="Error Admin not found",
                };
             }
             var token=_jWTService.GenerateToken(new(Id:admin.AdminId,Role:Roles.Admin));
             var session= await _unitOFWork.AdminSessionRepository.AddAsync(
                    new(){
                        AccessToken=token,
                        RefreshToken="",
                        AdminId=admin.AdminId,
                        Expires=DateTime.Now,
                        IPAddress=$"{context.Connection.RemoteIpAddress?.ToString()}",
                        DeviceInfo=$"{context.GetServerVariable("HTTP_USER_AGENT")}"
                    });
                if (session is null)
                {
                  return new(false)
                  {
                    ErrorMessage="Session Exception occured while creating session"
                  } ;  
                }
            _unitOFWork.Commit();
             
            return new(true)
            {
                Data=ToModelSession(session)
            };

        }
        catch (System.Exception e)
        {
            
              _logger.LogError($"Error occured at: {nameof(LoginAdmin)} Error Message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occured server please contact support "
            };
        }
    }
}