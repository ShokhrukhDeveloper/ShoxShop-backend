using ShoxShop.Entities;
using ShoxShop.Model;

namespace ShoxShop.Services.UserService;
public partial class UserService 
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
        UserModel ToUserModel(User model)
            => new()
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
        UserSessionModel ToUserSessionModel(UserSession session)
            => new()
            {
            IPAddress=session.IPAddress,
            UserSessionId=session.UserSessionId,
            UserId=session.UserId,
            RefreshToken=session.RefreshToken,
            Token=session.AccessToken,
            DeviceInfo=session.DeviceInfo,
            Expires=session.Expires,
            CreatedAt=session.CreatedAt,
            UpdatedAt=session.UpdatedAt           
            };
}