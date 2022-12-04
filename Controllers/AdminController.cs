using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos.Admin;
using ShoxShop.Services.Admin;
using ShoxShop.Services.JWT;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IJWTService _jWTService;
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService,IJWTService jWTService) 
    {
        _jWTService=jWTService;
        _adminService=adminService;
    }
    [HttpGet]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> Admin()
    {
        try
        {
            var data= _jWTService.Authenticate(HttpContext);
            var admin= await _adminService.GetAdminData(data!.Id);
            if (!admin.IsSuccess)
            {
                return NotFound(admin.ErrorMessage);
            }
            return Ok(admin);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}