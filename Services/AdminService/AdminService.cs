using ShoxShop.Dtos.Admin;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Admin;
public class AdminService : IAdminService
{
    private readonly IUnitOfWork _unitOFWork;
    public AdminService(IUnitOfWork unitOFWork)
    {
        _unitOFWork=unitOFWork;
    }
    public ValueTask CreateAdmin(AdminCreateDto adminCreateDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AdminSessionModel> DeleteAdminSession(ulong AdminId, ulong AdminSessionId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AdminModel> GetAdminData(ulong AdminId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AdminSessionModel> LoginAdmin(string PhoneNumber, string Password)
    {
        throw new NotImplementedException();
    }
}