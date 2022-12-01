
using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
namespace ShoxShop.Services.Admin;
public interface IAdminService
{
    ValueTask<Result<AdminSessionModel>> LoginAdmin(string PhoneNumber,string Password);
    ValueTask<Result<AdminSessionModel>> DeleteAdminSession(ulong AdminId,ulong AdminSessionId);
    ValueTask CreateAdmin(AdminCreateDto adminCreateDto);
    ValueTask<Result<AdminModel>>  GetAdminData(ulong AdminId);    

}