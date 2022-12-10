using ShoxShop.Dtos.Image;
using ShoxShop.Model;

namespace ShoxShop.Services.Image;
public interface IImageService
{
    ValueTask<Result<bool>> CreateImages(ulong VendorId,ulong ProductId,UploadImageDto dto);
    ValueTask<Result<ImageModel>> DeleteImage(ulong ImageId,ulong VendorId,ulong ProductId);

}