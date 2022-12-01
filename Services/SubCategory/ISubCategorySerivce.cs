using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;

namespace ShoxShop.Services.SubCategory;
public interface ISubCategorySerivce
{
   ValueTask<SubCategoryModel> CreateSubCategory(ulong adminId , CreateSubCategoryDto subCategoryDto); 
   ValueTask<SubCategoryModel> UpdateSubCategory(ulong subCategoryId,CreateSubCategoryDto subCategory);
   ValueTask<SubCategoryModel> DeleteSubCategory(ulong subCategoryId);
   ValueTask<SubCategoryModel> VisiblitySubCategory(ulong id,bool Visiblity);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesByCategoryId(ulong id);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesCategoryId(ulong id,ushort Limit=10,uint Page=1);
   ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategories(ushort Limit=10,uint Page=1);
}
