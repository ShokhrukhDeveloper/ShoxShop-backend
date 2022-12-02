using ShoxShop.Entities;
using ShoxShop.Model;
namespace ShoxShop.Services.Admin;
public partial class AdminService 
{
    AdminSessionModel ToModelSession(AdminSession session)
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
    AdminModel ToModelAdmin(Entities.Admin admin)
        =>new()
        {
            AdminId=admin.AdminId,
            FirstName=admin.FirstName,
            LastName=admin.LastName,
            Image=admin.Image,
            BirthDate=admin.BirthDate,
            
        };
}