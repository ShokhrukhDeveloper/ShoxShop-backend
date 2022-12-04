using ShoxShop.Dtos.Auth;
using ShoxShop.Model;

namespace ShoxShop.Controllers;
public partial class AuthController
{
    private AdminSessionDto ToAdminSessionDto(AdminSessionModel model)
        => new()
        {
            AdminSessionId=model.AdminSessionId,
            DeviceInfo=model.DeviceInfo,
            IPAddress=model.IPAddress,
            Expires=model.Expires,
            CareatedAt= model.CreatedAt,
            RefreshToken=model.RefreshToken,
            UpdatedAt=model.UpdatedAt
        };
    private VendorSessionDto ToVendorSessionDto(VendorSessionModel model)
        => new()
        {
            VendorSessionId=model.VendorSessionId,
            DeviceInfo=model.DeviceInfo,
            RefreshToken=model.RefreshToken,
            IPAddress=model.IPAddress,
            CreatedAt=model.CreatedAt,
            Expires=model.Expires,
            UpdatedAt=model.UpdatedAt
        }; 
    
}