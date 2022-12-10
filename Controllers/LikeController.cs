using Microsoft.AspNetCore.Mvc;
using ShoxShop.Services.JWT;
using ShoxShop.Services.LikeService;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;
    private readonly IJWTService _jWTService;

    public LikeController(ILikeService likeService,IJWTService jWTService)
    {
        _likeService=likeService;
        _jWTService=jWTService;
    }
    [HttpGet("{ProductId}")]
    public async Task<IActionResult> Like(ulong ProductId)
    {
        try
        {
            var data= _jWTService.Authenticate(HttpContext)!;
            var result= await _likeService.Like(
                1//data.Id
                ,
                ProductId
            );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            if (result.ErrorMessage is not null)
            {
                return Ok(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
        catch (System.Exception e)
        {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });    
        }
    }
}