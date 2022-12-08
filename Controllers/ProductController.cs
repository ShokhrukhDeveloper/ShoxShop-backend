using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Product;
using ShoxShop.Services.JWT;
using ShoxShop.Services.Product;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class ProductController : ControllerBase
{
    private readonly IJWTService _jWTService;
    private readonly IProductService _productService;

    public ProductController(IJWTService jWTService, IProductService productService)
    {
        _jWTService=jWTService;
        _productService=productService;
    }
    
    [HttpPost]
    // [Authorize(Roles=Roles.Vendor)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto dto)
    {
        try
        {
            // var data = _jWTService.Authenticate(HttpContext);
            var result= await _productService.CreateProduct(2,2,dto);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToProductDto(result.Data!));  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpPut("{ProductId}")]
    [Authorize(Roles=Roles.Vendor)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateProduct([FromRoute]ulong ProductId,[FromBody]CreateProductDto dto)
    {
        try
        {
            var data = _jWTService.Authenticate(HttpContext);
            var result= await _productService.UpdateProduct(data!.Id,ProductId,dto);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToProductDto(result.Data!));  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpDelete("{ProductId}")]
    [Authorize(Roles=Roles.Vendor)]
    public async Task<IActionResult> DeleteProduct([FromRoute]ulong ProductId)
    {
        try
        {
            var data = _jWTService.Authenticate(HttpContext);
            var result= await _productService.DeleteProduct(data!.Id,ProductId);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToProductDto(result.Data!));  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    [HttpPatch("{ProductId}/{Visibility}")]
    [Authorize(Roles = Roles.Vendor)]
    public async Task<IActionResult> ChangeVisibilityProduct([FromRoute]ulong ProductId,[FromRoute]bool Visibility)
    {
        try
        {
            var data = _jWTService.Authenticate(HttpContext);
            
            var result= await _productService.ChangeVisiblityProduct(data!.Id,ProductId,Visibility);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToProductDto(result.Data!));  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("Category/{CategoryId}/Invisible")]
        public async Task<IActionResult> GetAllInvisibleProductByCategoryId([FromRoute]ulong CategoryId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            var data = _jWTService.Authenticate(HttpContext);
            var result= await _productService.GetAllInvisibleProductByCategoryId(CategoryId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("SubCategory/{SubCategoryId}/Invisible")]
        public async Task<IActionResult> GetAllInvisibleProductBySubCategoryId([FromRoute]ulong SubCategoryId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            var data = _jWTService.Authenticate(HttpContext);
            var result= await _productService.GetAllInvisibleProductBySubCategoryId(SubCategoryId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("SubCategory/{SubCategoryId}")]
        public async Task<IActionResult> GetAllProductBySubCategoryId([FromRoute]ulong SubCategoryId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
           
            var result= await _productService.GetAllProductsBySubCategoryId(SubCategoryId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("Category/{CategoryId}")]
        public async Task<IActionResult> GetAllProductByCategoryId([FromRoute]ulong CategoryId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
           
            var result= await _productService.GetAllProductsByCategoryId(CategoryId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("Vendor/{VendorId}")]
        public async Task<IActionResult> GetAllProductsByVendorId([FromRoute]ulong? VendorId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
           VendorId??=_jWTService.Authenticate(HttpContext)!.Id;
            var result= await _productService.GetAllProductsByVendorId((ulong)VendorId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            
            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
        [HttpGet("Search/{SearchText}")]
        public async Task<IActionResult> SearchProduct(string SearchText,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            var result= await _productService.SearchProducts(SearchText,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }

            var pagenation= new ResponseBasePagenation<List<ProductDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data!.Select(ToProductDto).ToList()
            };
            return Ok(pagenation);  
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
    

}