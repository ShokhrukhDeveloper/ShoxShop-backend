using ShoxShop.Dtos.Vendor;
using ShoxShop.Model;

namespace ShoxShop.Controllers;

public partial class VendorController
{
    VendorDto ToVendorDto(VendorModel model)
        =>new()
        {
            VendorId=model.VendorId,
            MarketName=model.MarketName,
            FirstName=model.FirstName,
            LastName=model.LastName,
            Latitude=model.Latitude,
            Longitude=model.Longitude,
            DateOfBirth=model.DateOfBirth,
            Address=model.Address,
            Email=model.Email,
            Phone=model.Phone 
        };
}