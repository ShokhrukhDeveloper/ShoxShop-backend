using ShoxShop.Dtos.Category;
using ShoxShop.Model;
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
    public ValueTask<Result<CategoryModel>> ChangeVisiblityCategory(ulong CategoryId, bool Visiblity)
    {
        try
        {
            throw;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public async ValueTask<Result<CategoryModel>> CreateCategory(ulong AdminId,CreateCategoryDto CategoryDto)
    {
        try
        {
            var category =await _unitOfWork.CategoryRepository.AddAsync(
                new()
                {
                Name=CategoryDto.Name,
                Description=CategoryDto.Description,
                Image=CategoryDto.Image,
                Visiblity=CategoryDto.Visiblity,
                AdminId=AdminId
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
        catch (System.Exception)
        {
            
             _logger.LogError($"Error occured  at : {nameof(CreateCategory)} message: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error Occurred server please contact support"
            };
        }
    }

    public ValueTask<Result<List<CategoryModel>>> GetAllCategory(ushort Limit, uint Page)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<CategoryModel>>> GetAllInvisibleCategory(ushort Limit = 10, uint Page = 1)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<CategoryModel>> GetCategoryById(ulong CategoryId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<CategoryModel>>> SearchCategory(string SearchText)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<CategoryModel>> UpdateCategory(ulong CategoryId, CreateCategoryDto Category)
    {
        throw new NotImplementedException();
    }
}