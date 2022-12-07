using ShoxShop.Model;
using ShoxShop.Entities;

namespace ShoxShop.Services.Product;
public partial class ProductService 
{
    ProductModel ToProductModel(Entities.Product product)
        => new()
        {
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
}