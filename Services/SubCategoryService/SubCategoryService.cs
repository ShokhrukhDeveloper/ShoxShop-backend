using ShoxShop.Dtos.SubCategory;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.SubCategory;
public partial class SubCategoryService : ISubCategoryService
{
    private readonly ILogger<SubCategoryService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public SubCategoryService(IUnitOfWork unitOfWork,ILogger<SubCategoryService> logger)
    {
        _logger=logger;
        _unitOfWork=unitOfWork;
    }
    public async ValueTask<Result<SubCategoryModel>> ChangeVisiblitySubCategory(ulong id, bool Visiblity)
    {
        try
        {
            var subCategory= _unitOfWork
                    .SubCategoryRepository
                    .GetById(id);
            if (subCategory is null)
            {
                return new(false)
                {
                    ErrorMessage="Given subcategory Id not found"
                };
            }
            subCategory.Visiblity=Visiblity;
            var result=await _unitOfWork.SubCategoryRepository.Update(subCategory);
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while updating subcategory visiblity"
                };
            }
            return new(true)
            {
                Data=ToSubCategoryModel(result)  
            };
        }
        catch (System.Exception e)
        {
           _logger.LogError($"Error occured at: {nameof(ChangeVisiblitySubCategory)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<SubCategoryModel>> CreateSubCategory(ulong adminId, ulong CategoryId, CreateSubCategoryDto subCategoryDto)
    {
         try
        {
            var SubCategory= _unitOfWork
                    .CategoryRepository
                    .GetById(CategoryId);
            if (SubCategory is null)
            {
                return new(false)
                {
                    ErrorMessage="Given subcategory Id not found"
                };
            }
            
            var result=await _unitOfWork
                    .SubCategoryRepository
                    .AddAsync(
                        new(){
                            Name=subCategoryDto.Name,
                            Description=subCategoryDto.Description,
                            AdminId=adminId,
                            
                        });
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while updating subcategory visiblity"
                };
            }
            return new(true)
            {
                Data=ToSubCategoryModel(result)  
            };
        }
        catch (System.Exception e)
        {
           _logger.LogError($"Error occured at: {nameof(ChangeVisiblitySubCategory)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
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