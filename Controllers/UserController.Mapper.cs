using ShoxShop.Dtos.Product;
using ShoxShop.Dtos.User;
using ShoxShop.Model;

namespace ShoxShop.Controllers;

public partial class UserController{

 UserDto ToUserDto(UserModel model)
    =>new()
    {
        UserId=model.UserId,
        LastName=model.LastName,
        FirstName=model.FirstName,
        UserName=model.UserName,
        Address=model.Address,
        CreatedAt=model.CreatedAt,
        UpdatedAt=model.UpdatedAt,
        PhoneNumber=model.PhoneNumber,
        DateOfBirth=model.DateOfBirth,
        Image=model.Image  
    };
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