
using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
namespace ShoxShop.Services.Admin;
public interface IAdminService
{
    ValueTask<AdminSessionModel> LoginAdmin(string PhoneNumber,string Password);
    ValueTask<AdminSessionModel> DeleteAdminSession(ulong AdminId,ulong AdminSessionId);
    ValueTask CreateAdmin(AdminCreateDto adminCreateDto);
    ValueTask<AdminModel>  GetAdminData(ulong AdminId);    

}