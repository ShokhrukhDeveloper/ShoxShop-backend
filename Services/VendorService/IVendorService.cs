using ShoxShop.Dtos.Vendor;
using ShoxShop.Model;

namespace ShoxShop.Services.Vendor;
public interface IVendorService
{
    ValueTask<Result<VendorModel>> CreateVendor(CreateVendorDto createVendor);
    ValueTask<Result<VendorModel>> UpdateVendor(UpdateVendorDto createVendor);
    ValueTask<Result<VendorModel>> GetVendorById(ulong Id);
    ValueTask<Result<VendorSessionModel>> LoginVendor(VendorLoginModel vendorLogin);
    ValueTask<Result<VendorSessionModel>> DeleteVendorSession(ulong VendorId,ulong SesssionId);
    ValueTask<Result<List<VendorSessionModel>>> GetAllVendorSession(ulong VendorId);
    ValueTask<Result<List<VendorModel>>> GetAll(ushort Limit=10,uint Page=1);
    ValueTask<Result<List<VendorModel>>> Search(string SearchText);

    
}