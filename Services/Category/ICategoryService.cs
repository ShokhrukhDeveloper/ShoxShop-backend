using ShoxShop.Dtos.Category;
using ShoxShop.Model;
namespace ShoxShop.Services.Category;
public interface ICategoryService
{
    ValueTask<Result<CategoryModel>> CreateCategory(CreateCategoryDto CategoryDto);
    ValueTask<Result<CategoryModel>> UpdateCategory(ulong CategoryId,CreateCategoryDto Category);
    ValueTask<Result<CategoryModel>> DeleteCategory(ulong CategoryId);
    ValueTask<Result<CategoryModel>> ChangeVisiblityCategory(ulong CategoryId,bool Visiblity);
    ValueTask<Result<CategoryModel>> GetCategoryById(ulong CategoryId);
    ValueTask<Result<List<CategoryModel>>> GetAllCategory(ushort Limit,uint Page);
    ValueTask<Result<List<CategoryModel>>> GetAllInvisibleCategory(ushort Limit=10,uint Page=1);
    ValueTask<Result<List<CategoryModel>>> SearchCategory(string SearchText);

    

    
    
}