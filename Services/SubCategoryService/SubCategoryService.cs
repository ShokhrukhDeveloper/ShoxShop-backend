using Microsoft.EntityFrameworkCore;
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
            var category= _unitOfWork
                    .CategoryRepository
                    .GetById(CategoryId);
            if (category is null)
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
                            CetegoryId=CategoryId,
                            Visiblity=subCategoryDto.Visiblity,
                            Image=subCategoryDto.Image??"",
                            Delete=false,
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

    public async ValueTask<Result<SubCategoryModel>> DeleteSubCategory(ulong subCategoryId)
    {
        try
        {
            var SubCategory= _unitOfWork
                    .SubCategoryRepository
                    .GetById(subCategoryId);
            if (SubCategory is null)
            {
                return new(false)
                {
                    ErrorMessage="Given subcategory Id not found"
                };
            }
            SubCategory.Delete=true;
            var result=await _unitOfWork
                    .SubCategoryRepository
                    .Update(SubCategory);
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while deleting subcategory visiblity"
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

    public async ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategories(ushort Limit = 10, int Page = 1)
    {
          try
        {
            
            
            
            var query= _unitOfWork
                    .SubCategoryRepository
                    .GetEntities;
            var count=query.Count();
            var totalPage=(int)Math.Ceiling(count/(double)Limit);
            var result=await query.Skip((Page-1)*Limit)
                    .Take(Limit)    
                    .ToListAsync();
            await _unitOfWork.RollbackAsync();
                    
            if (result is null)
            {
                
                return new(false){
                    ErrorMessage="Error occured while Getting subcategory"
                };
            }
            return new(true)
            {
                CurrentPageIndex=Page,
                PageCount=totalPage,
                Data=result.Select(ToSubCategoryModel).ToList() 
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

    public async ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesByCategoryId(ulong id)
    {
           try
        {
            var result=await _unitOfWork
                    .SubCategoryRepository
                    .GetEntities.Where(w=>w.CetegoryId==id)
                    .ToListAsync();
            await _unitOfWork.RollbackAsync();
                    
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while Getting subcategory"
                };
            }
            return new(true)
            {
                Data=result.Select(ToSubCategoryModel).ToList() 
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

    public async ValueTask<Result<List<SubCategoryModel>>> GetAllSubCategoriesCategoryIdPagenated(ulong id, ushort Limit = 10, int Page = 1)
    {
        try
        {      
            var query= _unitOfWork
                    .SubCategoryRepository
                    .GetEntities
                    .Where(w=>w.CetegoryId==id);
            var count=query.Count();
            var result=await query
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToListAsync();
            var totalPage=(int)Math.Ceiling(count/(double)Limit);
            await _unitOfWork.RollbackAsync();    
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while Getting subcategory"
                };
            }
            return new(true)
            {
                Data=result.Select(ToSubCategoryModel).ToList() 
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

    public async ValueTask<Result<SubCategoryModel>> UpdateSubCategory(ulong subCategoryId, CreateSubCategoryDto subCategory)
    {
       try
        {
            var subCategoryEntity= _unitOfWork
                    .SubCategoryRepository
                    .GetById(subCategoryId);
            if (subCategoryEntity is null)
            {
                return new(false)
                {
                    ErrorMessage="Given subcategory Id not found"
                };
            }
            subCategoryEntity.Name=subCategory.Name;
            subCategoryEntity.Description=subCategory.Description;
            subCategoryEntity.Image=subCategory.Image??"";
            subCategoryEntity.Visiblity=subCategory.Visiblity;
            
            var result=await _unitOfWork
                    .SubCategoryRepository
                    .Update(subCategoryEntity);
            if (result is null)
            {
                return new(false){
                    ErrorMessage="Error occured while updating subcategory"
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
}