using ShoxShop.Model;

namespace ShoxShop.Services.SubCategory;
public partial class SubCategoryService
{
    SubCategoryModel ToSubCategoryModel(Entities.SubCategory category)
        => new()
        {
            Name=category.Name,
            SubCategoryId=category.SubCategoryId,
            Description=category.Description,
            CetegoryId=category.CetegoryId,
            CreatedAt=category.CreatedAt,
            UpdatedAt=category.UpdatedAt,
            Image=category.Image,
            Visiblity=category.Visiblity,
            Delete=category.Delete

        };
}