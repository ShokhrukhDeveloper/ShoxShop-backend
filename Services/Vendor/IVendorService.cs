using ShoxShop.Dtos.Vendor;
using ShoxShop.Model;

namespace ShoxShop.Services.Vendor;
public interface IVendorService
{
    ValueTask<VendorModel> CreateVendor(CreateVendorDto createVendor);
    ValueTask<VendorModel> UpdateVendor(UpdateVendorDto createVendor);
    ValueTask<VendorModel> GetVendorById(ulong Id);
    ValueTask<Result<List<VendorModel>>> GetAll(ushort Limit,uint Page);
    ValueTask<Result<List<VendorModel>>> Search(string SearchText);
}