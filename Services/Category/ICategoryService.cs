using ShoxShop.Dtos.Category;
using ShoxShop.Model;
namespace ShoxShop.Services.Category;
public interface ICategoryService
{
    ValueTask<CategoryModel> CreateCategory(CreateCategoryDto CategoryDto);
    ValueTask<CategoryModel> UpdateCategory(ulong CategoryId,CreateCategoryDto Category);
    ValueTask<CategoryModel> DeleteCategory(ulong CategoryId);
    ValueTask<CategoryModel> VisiblityChangeCategory(ulong CategoryId,bool Visiblity);
    ValueTask<CategoryModel> GetCategoryById(ulong CategoryId);
    ValueTask<Result<List<CategoryModel>>> GetAllCategory(ushort Limit,uint Page);
    ValueTask<Result<List<CategoryModel>>> GetAllInvisibleCategory(ushort Limit=10,uint Page=1);
    ValueTask<Result<List<CategoryModel>>> SearchCategory(string SearchText);

    

    
    
}