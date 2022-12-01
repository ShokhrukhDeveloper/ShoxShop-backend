using Microsoft.EntityFrameworkCore;
using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Admin;
public partial class AdminService : IAdminService
{
    private readonly IUnitOfWork _unitOFWork;
    public AdminService(IUnitOfWork unitOFWork)
    {
        _unitOFWork=unitOFWork;
    }
    public async ValueTask CreateAdmin(AdminCreateDto adminCreateDto)
    {
        
    }

    public ValueTask<Result<AdminSessionModel>> DeleteAdminSession(ulong AdminId, ulong AdminSessionId)
    {
           throw new NotImplementedException();
        try
        {
        }
        catch (System.Exception e)
        {
            
            throw;
        }
    }

    public ValueTask<Result<AdminModel>> GetAdminData(ulong AdminId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<AdminSessionModel>> LoginAdmin(string PhoneNumber, string Password)
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
             var session= await _unitOFWork.AdminSessionRepository.AddAsync(
                    new(){
                        AccessToken="AccessToken",
                        RefreshToken="RefreshToken",
                        AdminId=admin.AdminId,
                        Expires=DateTime.Now,
                        IPAddress="12.10.11.22",
                        DeviceInfo="Andoid 12"
                    });
                if (session is null)
                {
                  return new(false)
                  {
                    ErrorMessage="Session Exception occured Server"
                  } ;  
                }
            _unitOFWork.Commit();
             
            return new(true)
            {
                Data=ToModel(session)
            };

        }
        catch (System.Exception e)
        {
            
            throw new Exception();
        }
    }
}