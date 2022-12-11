using ShoxShop.Model;
using ShoxShop.Entities;

namespace ShoxShop.Services.Product;
public partial class ProductService 
{
    ProductModel ToProductModel(Entities.Product product)
        => new()
        {
            Name=product.Name,
            ProductId=product.ProductId,
            Price=product.Price,
            CategoryId=product.CategoryId,
            Description=product.Description,
            SubCategoryId=product.SubCategoryId,
            CoverImage=product.CoverImage,
            Delete=product.Delete,
            Visiblity=product.Visiblity,
            VendorId=product.VendorId  
        };
    SubCategoryModel? ToSubCategoryModel(Entities.SubCategory category)
        => new()
        {
            Name=category.Name,
            SubCategoryId=category.SubCategoryId,
            Description=category.Description,
            CetegoryId=category.CetegoryId,
            CreatedAt=category.CreatedAt,
            UpdatedAt=category.UpdatedAt,
            Image=category.Image,
            // Visiblity=category.Visiblity,
            // Delete=category.Delete
        };
    private ImageModel ToImageModel(Entities.Image image)
        =>new()
        {
            ImageId=image.ImageId,
            ImageUrl=image.ImageUrl,
            ProductId=image.ProductId,
            Title=image.Title,
            Desription=image.Desription
        };
    VendorModel ToModelVendor(Entities.Vendor vendor)
        =>new()
        {
            VendorId=vendor.VendorId,
            LastName=vendor.LastName??"",
            FirstName=vendor.FirstName,
            MarketName=vendor.MarketName,
            Address=vendor.Address,
            // AdminId=vendor.AdminId,
            Latitude=vendor.Latitude,
            Longitude=vendor.Longitude,
            DateOfBirth=vendor.DateOfBirth,
            Email=vendor.Email,
            Phone=vendor.Phone,
            // Blocked=vendor.Blocked,
            Image=vendor.Image,
            
        };
}