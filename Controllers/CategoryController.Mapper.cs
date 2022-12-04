using ShoxShop.Dtos.Category;
using ShoxShop.Model;

namespace ShoxShop.Controllers;

public partial class CategoryController 
{
    CategoryDto ToCategoryDto(CategoryModel model)
        => new()
        {
            Image=model.Image??"",
            Name=model.Name,
            Description=model.Description,
            CategoryId=model.CategoryId,
            CreatedAt=model.CreatedAt,
            UpdatedAt=model.UpdatedAt
        };

       
    

}