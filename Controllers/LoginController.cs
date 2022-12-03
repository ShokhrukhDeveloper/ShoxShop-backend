using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Admin;
using ShoxShop.Services.Admin;
using ShoxShop.Services.Vendor;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IVendorService _vendorService;
    private readonly IAdminService _adminService;

    public LoginController(IAdminService adminService,IVendorService vendorService)
    {
      _adminService=adminService;
      _vendorService=vendorService;  
    }
    [HttpPost("Admin")]
    public async Task<IActionResult> LoginAdminAsync([FromBody]Login admin)
    {
      try
      {
        var result= await _adminService.LoginAdmin(admin.Phone!,admin.Password!);
        if (!result.IsSuccess)
        {
          return NotFound(result.ErrorMessage);
        }
        return Ok(result);
      }
      catch (System.Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
    [HttpPost("Vendor")]
    public async Task<IActionResult> LoginVendorAsync([FromBody]Login vendor)
    {
      try
      {
        var result =await _vendorService.LoginVendor(vendor.Phone!,vendor.Password!);
        return Ok(result);
      }
      catch (System.Exception e)
      {
        
       return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }

}