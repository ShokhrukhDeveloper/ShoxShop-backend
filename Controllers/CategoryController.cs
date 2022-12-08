using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Category;
using ShoxShop.Services.Category;
using ShoxShop.Services.JWT;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IJWTService _jWTService;

    public CategoryController(ICategoryService categoryService,IJWTService jWTService)
    {
        _categoryService=categoryService;
        _jWTService=jWTService;
    }

    [HttpPost]
    // [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryDto createCategory)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state is invalid");
            }
            var data= _jWTService.Authenticate(HttpContext);
            var category = await _categoryService.CreateCategory(data!.Id,createCategory);
            return Ok(ToCategoryDto(category.Data!));
        }
        catch (System.Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpDelete("{CategoryId}")]
    public async Task<IActionResult> DeleteCategory([FromRoute]ulong CategoryId)
    {
        try
        {
            var result = await _categoryService.DeleteCategory(CategoryId);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    
    [HttpGet("All")]
    public async Task<IActionResult> GetAllCategories([FromQuery]Pagination pagination)
    {
        try
        {
            var result=await _categoryService.GetAllCategory(pagination.Limit,pagination.Page);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            var page= new ResponseBasePagenation<List<CategoryDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data?.Select(ToCategoryDto).ToList()
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpGet("AllInvisible")]
    public async Task<IActionResult> GetAllInvisibleCategories([FromQuery]Pagination pagination)
    {
        try
        {
            var result=await _categoryService.GetAllInvisibleCategory(pagination.Limit,pagination.Page);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            var page= new ResponseBasePagenation<List<CategoryDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data?.Select(ToCategoryDto).ToList()
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }

    [HttpPut("{CategoryId}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]ulong CategoryId,[FromBody]CreateCategoryDto update)
    {
        try
        {
            var result=await _categoryService.UpdateCategory(CategoryId,update);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(ToCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpPatch("{CategoryId}/{Visiblity}")]
    public async Task<IActionResult> ChangeCategoryVisibility([FromRoute]ulong CategoryId,[FromRoute]bool Visiblity)
    {
        try
        {
            var result=await _categoryService.ChangeVisiblityCategory(CategoryId,Visiblity);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result.Data?.Visiblity);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpGet("Search")]
    public async Task<IActionResult> ChangeCategory([FromQuery,Required]string text)
    {
        try
        {
            var result=await _categoryService.SearchCategory(text);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            var page= new ResponseBasePagenation<List<CategoryDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data?.Select(ToCategoryDto).ToList()
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
}