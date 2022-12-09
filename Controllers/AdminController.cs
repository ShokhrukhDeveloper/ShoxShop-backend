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
public partial class AdminController : ControllerBase
{
    private readonly IJWTService _jWTService;
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService,IJWTService jWTService) 
    {
        _jWTService=jWTService;
        _adminService=adminService;
    }
    [HttpGet]
    // [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> GetDataAdmin()
    {
        try
        {
            var data= _jWTService.Authenticate(HttpContext);
            var admin= await _adminService.GetAdminData(
                data!.Id
                );
            if (!admin.IsSuccess)
            {
                return NotFound(admin.ErrorMessage);
            }
            return Ok(ToAdminDto(admin.Data!));
        }
        catch (System.Exception e)
        {
            
             return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpPut]
    [Consumes("multipart/form-data")]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> UpdateAdmin([FromForm]UpdateAdminData dto)
    {
        try
        {
            var data= _jWTService.Authenticate(HttpContext);
            var admin= await _adminService.UpdateAdmin(
            data!.Id,
                dto);
            if (!admin.IsSuccess)
            {
                return NotFound(admin.ErrorMessage);
            }
            return Ok(ToAdminDto(admin.Data!));
        }
        catch (System.Exception e)
        {
            
             return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    
}