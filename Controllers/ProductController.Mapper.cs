using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Product;
using ShoxShop.Model;

namespace ShoxShop.Controllers;

public partial class ProductController 
{
    ProductDto ToProductDto(ProductModel model)
        => new()
        {
            ProductId=model.ProductId,
            Price=model.Price,
            Name=model.Name,
            Description=model.Description,
            SubCategoryId=model.SubCategoryId,
            Quantity=model.Quantity,
            CoverImage=model.CoverImage,
            Visiblity=model.Visiblity,
            CategoryId=model.CategoryId
        };
}