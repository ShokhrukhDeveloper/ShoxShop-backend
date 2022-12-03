using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;

namespace ShoxShop.Services.SubCategory;
public partial class SubCategoryService : ISubCategoryService
{
    public ValueTask<Result<SubCategoryModel>> ChangeVisiblitySubCategory(ulong id, bool Visiblity)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<SubCategoryModel>> CreateSubCategory(ulong adminId, ulong CategoryId, CreateSubCategoryDto subCategoryDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<SubCategoryModel>> DeleteSubCategory(ulong subCategoryId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategories(ushort Limit = 10, uint Page = 1)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesByCategoryId(ulong id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesCategoryId(ulong id, ushort Limit = 10, uint Page = 1)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<SubCategoryModel>> UpdateSubCategory(ulong subCategoryId, CreateSubCategoryDto subCategory)
    {
        throw new NotImplementedException();
    }
}