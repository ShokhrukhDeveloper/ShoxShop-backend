
using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
namespace ShoxShop.Services.Admin;
public interface IAdminService
{
    ValueTask<AdminLoginModel> LoginAdmin(string PhoneNumber,string Password);
    ValueTask CreateAdmin(AdminCreateDto adminCreateDto);
    ValueTask<AdminModel>  GetAdminData(ulong AdminId);    

}