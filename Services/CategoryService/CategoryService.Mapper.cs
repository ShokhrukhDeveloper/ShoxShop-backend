using ShoxShop.Dtos.Category;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Category;
public partial class CategoryService
{
    private CategoryModel ToModelCatrgory(Entities.Category category)
        => new()
        {
            CategoryId=category.CategoryId,
            Name=category.Name,
            Description=category.Description,
            Delete=category.Delete,
            AdminId=category.AdminId,
            CreatedAt=category.CreatedAt,
            UpdatedAt=category.UpdatedAt
        };
}