using ShoxShop.Const;
using ShoxShop.Dtos.Image;
using ShoxShop.Model;
using ShoxShop.Services.File;
using ShoxShop.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ShoxShop.Services.Image;
public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ImageService> _logger;

    public ImageService(IUnitOfWork unitOfWork,ILogger<ImageService>logger)
    {
        _unitOfWork=unitOfWork;
        _logger=logger;
    }
    public async ValueTask<Result<bool>> CreateImages(ulong VendorId, ulong ProductId, UploadImageDto dto)
    {
        try
        {
            var product =  _unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id product not found"
                };
            }
            if (product.VendorId!=VendorId)
            {
                return new(false)
                {
                    ErrorMessage="You cant add image this product product added by another vendor"
                };
            }

            var fileService= new FileService();
            var images= await fileService.SaveFilesList(dto.images.ToList(),FileConst.ProductImages);
            var imageEntities=images.Select(
                e=>new Entities.Image(){
                            Title=dto.Title??"<|>",
                            Desription=dto.Description,
                            ImageUrl=e,
                            ProductId=ProductId,
                            }    ).ToList();
            await _unitOfWork.ImageRepository.AddListAsync(imageEntities);
            return new(true)
            {
                Data=true
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateImages)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<ImageModel>> DeleteImage(ulong ImageId, ulong VendorId, ulong ProductId)
    {
        try
        {
            var product =  _unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                return new(false)
                {
                    ErrorMessage="Given Id product not found"
                };
            }
            if (product.VendorId!=VendorId)
            {
                return new(false)
                {
                    ErrorMessage="You cant add image this product product added by another vendor"
                };
            }

            var fileService= new FileService();
            // var images= await fileService.SaveFilesList(dto.images.ToList(),FileConst.ProductImages);
            
            var result =  _unitOfWork.ImageRepository.
                        Find(e=>e.ProductId==ProductId&&ImageId==e.ImageId).
                        FirstOrDefault();
            if (result is null)
            {
                return  new(false)
                {
                    ErrorMessage="Image not found"
                };
            }
            var deletedImage = await _unitOfWork.ImageRepository.Remove(result);
            return new(true)
            {
                Data=ToImageModel(deletedImage)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateImages)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }
    private ImageModel ToImageModel(Entities.Image image)
        =>new()
        {
            ImageId=image.ImageId,
            ImageUrl=image.ImageUrl,
            ProductId=image.ProductId,
            Title=image.Title,
            Desription=image.Desription
        };
}