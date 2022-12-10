using Microsoft.AspNetCore.Mvc;
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
}