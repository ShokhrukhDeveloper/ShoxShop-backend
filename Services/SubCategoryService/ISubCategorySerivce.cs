using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;

namespace ShoxShop.Services.SubCategory;
public interface ISubCategorySerivce
{
   ValueTask<Result<SubCategoryModel>> CreateSubCategory(ulong adminId,ulong CategoryId,CreateSubCategoryDto subCategoryDto); 
   ValueTask<Result<SubCategoryModel>> UpdateSubCategory(ulong subCategoryId,CreateSubCategoryDto subCategory);
   ValueTask<Result<SubCategoryModel>> DeleteSubCategory(ulong subCategoryId);
   ValueTask<Result<SubCategoryModel>> ChangeVisiblitySubCategory(ulong id,bool Visiblity);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesByCategoryId(ulong id);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesCategoryId(ulong id,ushort Limit=10,uint Page=1);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategories(ushort Limit=10,uint Page=1);
}
