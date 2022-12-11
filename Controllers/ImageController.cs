using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Image;
using ShoxShop.Services.Image;
using ShoxShop.Services.JWT;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly IJWTService _jWTService;

    public ImageController(IImageService imageService,IJWTService jWTService)
   {
    _imageService=imageService;
    _jWTService=jWTService;
   } 
   [HttpPost("{ProductId}")][Consumes("multipart/form-data")]
   public async Task<IActionResult> UploadImages([FromRoute]ulong ProductId,[FromForm]UploadImageDto dto)
   {
    try
    {
        // var data = _jWTService.Authenticate(HttpContext)!;
        var result = await _imageService.CreateImages(
           1, // data.Id,
            ProductId,
            dto);
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
   [HttpDelete("{ProductId}/{ImageId}")]
   public async Task<IActionResult> UploadImages([FromRoute]ulong ProductId,ulong ImageId)
   {
    try
    {
        // var data = _jWTService.Authenticate(HttpContext)!;
        var result = await _imageService.DeleteImage(
           ImageId ,
            1,// data.Id,
            ProductId
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