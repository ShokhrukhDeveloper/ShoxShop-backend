
using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
namespace ShoxShop.Services.Admin;
public interface IAdminService
{
    ValueTask<Result<AdminSessionModel>> LoginAdmin(string PhoneNumber,string Password,HttpContext content);
    ValueTask<Result<AdminSessionModel>> DeleteAdminSession(ulong AdminId,ulong AdminSessionId);
    ValueTask<Result<List<AdminSessionModel>>> GetAllAdminSession(ulong AdminId,ushort Limit,int Page);
    
    ValueTask CreateAdmin(AdminCreateDto adminCreateDto);
    ValueTask<Result<AdminModel>>  GetAdminData(ulong AdminId);    

}