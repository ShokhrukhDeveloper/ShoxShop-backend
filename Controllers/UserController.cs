using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Product;
using ShoxShop.Dtos.User;
using ShoxShop.Services.JWT;
using ShoxShop.Services.UserService;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJWTService _jWTService;

    public UserController(IUserService userService,IJWTService jWTService)
    {
        _userService=userService;
        _jWTService=jWTService;
    }
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateUser([FromForm]CreateUserDto dto)
    {
        try
        {
            var result= await _userService.CreateUser(dto);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            if (result.Data is null)
            {
               return NotFound(result.ErrorMessage); 
            }
            return Ok(ToUserDto(result.Data));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    [HttpPut][Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateUser([FromForm]CreateUserDto dto)
    {
        try
        {
            var result= await _userService.CreateUser(dto);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToUserDto(result.Data!));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    [HttpGet]
    public async Task<IActionResult> GetUserData()
    {
        try
        {
            // var data= _jWTService.Authenticate(HttpContext)!;
            var result= await _userService.GetUserDataByUserId(
                1   // data.Id
                );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToUserDto(result.Data!));
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    [HttpPost("Favoirate/{ProductId}")]
    public async Task<IActionResult> CreateFavoirateUser([FromRoute]ulong ProductId)
    {
        try
        {
            // var data= _jWTService.Authenticate(HttpContext)!;
            var result= await _userService.CreateFavoirateByUserId(
                1   // data.Id
                ,
                ProductId
                );
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
    
    [HttpGet("Favoirates")]
    public async Task<IActionResult> GetFavoiratesUser([FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            // var data= _jWTService.Authenticate(HttpContext)!;
            var result= await _userService.GetFavoiratesByUserId(
                1   // data.Id
                ,Limit,Page
                );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var pagenate=  new ResponseBasePagenation<List<ProductDto>>()
            {
                CurrentPage=result.CurrentPageIndex,
                TotalPage=result.PageCount,
                Data=result.Data?.Select(ToProductDto).ToList()
            };
            return Ok(pagenate);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    [HttpDelete("Favoirate/{ProductId}")]
    public async Task<IActionResult> CreaaFavoirateUser([FromRoute]ulong ProductId)
    {
        try
        {
            // var data= _jWTService.Authenticate(HttpContext)!;
            var result= await _userService.DeleteFavoirateById(
               ProductId,
                1   // data.Id
                );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            
            return Ok(result.Data);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
}