using ShoxShop.Const;
using ShoxShop.Dtos.Category;
using ShoxShop.Model;
using ShoxShop.Services.File;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.Category;
public partial class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(IUnitOfWork unitOfWork,ILogger<CategoryService> logger)
    {
        _unitOfWork=unitOfWork;
        _logger=logger;
    }
    public async ValueTask<Result<CategoryModel>> ChangeVisiblityCategory(ulong CategoryId, bool Visiblity)
    {
        try
        {
            var result = _unitOfWork.CategoryRepository.GetById(CategoryId);
            if (result is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Givent id category not found"
                };
            }
            result.Visiblity=Visiblity;
            var res=await _unitOfWork.CategoryRepository.Update(result);
            return new(true)
            {
                Data=ToModelCatrgory(res)
            };
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured  at : {nameof(CreateCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<CategoryModel>> CreateCategory(ulong AdminId,CreateCategoryDto CategoryDto)
    {
        try
        {
            var fileService= new FileService();
            var image= await fileService.SaveFile(CategoryDto.Image,FileConst.CategoryImages);
            var category =await _unitOfWork.CategoryRepository.AddAsync(
                new()
                {
                Name=CategoryDto.Name,
                Description=CategoryDto.Description??"",
                Image=image,
                Visiblity=CategoryDto.Visiblity,
                AdminId=AdminId,
                }
            );
            await  _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelCatrgory(category)
            };
        }
        catch (System.Exception e)
        {
            
            _logger.LogError($"Error occured  at : {nameof(CreateCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }



    public async ValueTask<Result<CategoryModel>> DeleteCategory(ulong CategoryId)
    {
        try
        {
            var category= _unitOfWork.CategoryRepository.GetById(CategoryId);
            if (category is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given Id category not found"
                };
            }
            var categResult= await _unitOfWork.CategoryRepository.Remove(category);
            return new(true)
            {
                Data=ToModelCatrgory(categResult)
            };
            
        }
        catch (System.Exception e)
        {
            
             _logger.LogError($"Error occured  at : {nameof(DeleteCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<List<CategoryModel>>> GetAllCategory(ushort Limit=10, int Page=1)
    {
        try
        {
            var count= _unitOfWork
                    .CategoryRepository
                    .GetEntities.Count();
            var result= _unitOfWork
                    .CategoryRepository
                    .GetEntities
                    .Where(w=>w.Visiblity&&w.Delete!=true)
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToList();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                CurrentPageIndex=Page,
                PageCount=totalPage,
                Data=result.Select(ToModelCatrgory).ToList()
            };
        }
        catch (System.Exception e)
        {
             _logger.LogError($"Error occured  at : {nameof(GetAllCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            }; 
            
        }
    }

    public async ValueTask<Result<List<CategoryModel>>> GetAllInvisibleCategory(ushort Limit = 10, int Page = 1)
    {
          try
        {
            var count= _unitOfWork
                    .CategoryRepository
                    .GetEntities.Count();
            var result= _unitOfWork
                    .CategoryRepository
                    .GetEntities
                    .Where(w=>!w.Visiblity)
                    .Skip((Page-1)*Limit)
                    .Take(Limit)
                    .ToList();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                CurrentPageIndex=Page,
                PageCount=totalPage,
                Data=result.Select(ToModelCatrgory).ToList()
            };
        }
        catch (System.Exception e)
        {
             _logger.LogError($"Error occured  at : {nameof(GetAllInvisibleCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            }; 
            
        }
    }

    public async ValueTask<Result<CategoryModel>> GetCategoryById(ulong CategoryId)
    {
        try
        {
            var category = _unitOfWork
                            .CategoryRepository
                            .GetById(CategoryId);
            if (category is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given gategory Id  not found"
                };
            }
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=ToModelCatrgory(category)
            };
        }
        catch (System.Exception e)
        {
            
             _logger.LogError($"Error occured  at : {nameof(GetCategoryById)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }



    }

    public async ValueTask<Result<List<CategoryModel>>> SearchCategory(string SearchText, ushort Limit=10,int Page=1)
    {
        try
        {
            var query= _unitOfWork
                    .CategoryRepository
                    .GetEntities
                    .Where(q=>q.Name.Contains(SearchText)&&q.Delete!=true&&q.Visiblity)
                    .Skip((Page-1)*Limit)
                    .Take(Limit);
            var count=query.Count();
            var result=query.ToList();
            var totalPage= (int)Math.Ceiling(count/(double)Limit);
            await _unitOfWork.RollbackAsync();
            return new(true)
            {
                Data=result.Select(ToModelCatrgory).ToList()
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured  at : {nameof(SearchCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<CategoryModel>> UpdateCategory(ulong CategoryId, UpdateCategoryDto Category)
    {
        try
        {
            var category=_unitOfWork
                    .CategoryRepository
                    .GetById(CategoryId);
            if (category is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given id category not found"
                };
            }
            string? image=null;
            if (Category.Image is not null)
            {
            var fileService= new FileService();
            image= await fileService.SaveFile(Category.Image,FileConst.CategoryImages);
            }
            category.Name=Category.Name??category.Name;
            category.Description=Category.Description??category.Description;
            category.Visiblity=Category.Visiblity??category.Visiblity;
            category.Image=image??category.Image;
            var result=await _unitOfWork.CategoryRepository.Update(category);
            return new(true)
            {
                Data=ToModelCatrgory(result)  
            };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured  at : {nameof(UpdateCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }
}