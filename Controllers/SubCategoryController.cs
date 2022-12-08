using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos;
using ShoxShop.Dtos.SubCategory;
using ShoxShop.Services.JWT;
using ShoxShop.Services.SubCategory;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCatogryService;
    private readonly IJWTService _jWTService;

    public SubCategoryController(ISubCategoryService subCatogryService, IJWTService jWTService)
    {
        _subCatogryService=subCatogryService;
        _jWTService=jWTService;
    }

    [HttpGet("All/{CategoryId}")]
    public async Task<IActionResult> GetAllSubCategoriesByCategoryId([FromRoute]ulong CategoryId)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var result = await _subCatogryService.GetAllSubCategoriesByCategoryId(CategoryId);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            var page= new ResponseBasePagenation<List<SubCategoryDto>>()
            {
                Data=result.Data!.Select(ToSubCategoryDto).ToList(),
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpGet("{CategoryId}")]
    public async Task<IActionResult> GetAllSubCategoriesByCategoryIdPagenated([FromRoute]ulong CategoryId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var result = await _subCatogryService.GetAllSubCategoriesCategoryIdPagenated(CategoryId,Limit,Page);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            var page= new ResponseBasePagenation<List<SubCategoryDto>>()
            {
                Data=result.Data!.Select(ToSubCategoryDto).ToList(),
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpGet("All")]
    public async Task<IActionResult> GetAllSubCategories([FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var result = await _subCatogryService.GetAllSubCategories(Limit,Page);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            var page= new ResponseBasePagenation<List<SubCategoryDto>>()
            {
                Data=result.Data!.Select(ToSubCategoryDto).ToList(),
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpPost("{CategoryId}")]
    // [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateSubCategory([FromRoute]ulong CategoryId,[FromBody]CreateSubCategoryDto  subCategoryDtos)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            // var data=_jWTService.Authenticate(HttpContext);
            var result = await _subCatogryService.CreateSubCategory(1,CategoryId,subCategoryDtos);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            return Ok(ToSubCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpPut("{CategoryId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateSubCategory([FromRoute]ulong SubCategoryId, [FromQuery]CreateSubCategoryDto  subCategoryDtos)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var data=_jWTService.Authenticate(HttpContext);
            var result = await _subCatogryService.UpdateSubCategory(SubCategoryId,subCategoryDtos);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            return Ok(ToSubCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpDelete("{SubCategoryId}")]
    public async Task<IActionResult> DeleteSubCategory([FromRoute]ulong SubCategoryId)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var data=_jWTService.Authenticate(HttpContext);
            var result = await _subCatogryService.DeleteSubCategory(SubCategoryId);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            return Ok(ToSubCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
        
    }
    [HttpPatch("{SubCategoryId}/{Visiblity}")]
    public async Task<IActionResult> ChangeVisiblitySubCategory([FromRoute]ulong SubCategoryId,[FromRoute]bool Visiblity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return NotFound("Model state invalid");
            }
            var data=_jWTService.Authenticate(HttpContext);
            var result = await _subCatogryService.ChangeVisiblitySubCategory(SubCategoryId,Visiblity);
            if(!result.IsSuccess)
            {
                return  NotFound(result.ErrorMessage);
            }
            return Ok(ToSubCategoryDto(result.Data!));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }    
    }
    

}