using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;

namespace ShoxShop.Services.SubCategory;
public interface ISubCategoryService
{
   ValueTask<Result<SubCategoryModel>> CreateSubCategory(ulong adminId,ulong CategoryId,CreateSubCategoryDto subCategoryDto); 
   ValueTask<Result<SubCategoryModel>> UpdateSubCategory(ulong subCategoryId,UpdateSubCategoryDto subCategory);
   ValueTask<Result<SubCategoryModel>> DeleteSubCategory(ulong subCategoryId);
   ValueTask<Result<SubCategoryModel>> ChangeVisiblitySubCategory(ulong id,bool Visiblity);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesByCategoryId(ulong id);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesCategoryIdPagenated(ulong CategoryId,ushort Limit=10,int Page=1);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategories(ushort Limit=10,int Page=1);
}
