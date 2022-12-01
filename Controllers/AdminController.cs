using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Admin;
using ShoxShop.Services.Admin;

namespace ShoxShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService=adminService;
    }
    [HttpPost]
    public IActionResult LoginAdmin(LoginAdminDto login)
    {
        try
        {
           
        }
        catch (System.Exception e)
        {
            
            throw;
        }
        return Ok();
    }
}