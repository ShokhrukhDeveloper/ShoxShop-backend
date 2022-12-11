using Microsoft.AspNetCore.Mvc;
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
    // public Task<IActionResult> 
}