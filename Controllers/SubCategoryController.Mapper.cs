using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;

namespace ShoxShop.Controllers;

public partial class SubCategoryController
{
    SubCategoryDto  ToSubCategoryDto(SubCategoryModel model)
        => new()
        {
            Name=model.Name,
            SubCategoryId=model.SubCategoryId,
            Description=model.Description,
            CategoryId=model.CetegoryId,
            Image=model.Image?? "",
            CreatedAt=model.CreatedAt,
            UpdatedAt=model.UpdatedAt
        };
}