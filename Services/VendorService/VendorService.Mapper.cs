using ShoxShop.Model;
using ShoxShop.UnitOfWork;
#pragma warning disable
namespace ShoxShop.Services.Vendor;
public partial class VendorService
{
    VendorModel ToModelVendor(Entities.Vendor vendor)
        =>new()
        {
            VendorId=vendor.VendorId,
            LastName=vendor.LastName,
            FirstName=vendor.FirstName,
            MarketName=vendor.MarketName,
            Address=vendor.Address,
            AdminId=vendor.AdminId,
            Latitude=vendor.Latitude,
            Longitude=vendor.Longitude,
            DateOfBirth=vendor.DateOfBirth,
            Email=vendor.Email,
            Phone=vendor.Phone,
            Blocked=vendor.Blocked
        };
    VendorSessionModel ToModelVendorSession(Entities.VendorSession session)
        => new()
        {
            VendorSessionId=session.VendorId,
            VendorId=session.VendorId,
            Token=session.AccessToken,
            RefreshToken=session.RefreshToken,
            Expires=session.Expires,
            DeviceInfo=session.DeviceInfo,
            IPAddress=session.IPAddress,
            
        };
}