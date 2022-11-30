using ShoxShop.Dtos.Vendor;
using ShoxShop.Model;

namespace ShoxShop.Services.Vendor;
public interface IVendorService
{
    ValueTask<VendorModel> CreateVendor(CreateVendorDto createVendor);
    
}