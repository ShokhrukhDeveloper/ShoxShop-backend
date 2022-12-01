using ShoxShop.Dtos.Admin;
using ShoxShop.Entities;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;
namespace ShoxShop.Services.Admin;
public partial class AdminService 
{
    AdminSessionModel ToModel(AdminSession session)
        => new()
        {
            AccessToken=session.AccessToken,
            RefreshToken=session.RefreshToken,
            DeviceInfo=session.DeviceInfo,
            AdminId=session.AdminId,
            Expires=session.Expires,
            AdminSessionId=session.AdminSessionId,
            IPAddress=session.IPAddress
        };
}