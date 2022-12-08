using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Admin;
using ShoxShop.Dtos.Auth;
using ShoxShop.Services.Admin;
using ShoxShop.Services.JWT;
using ShoxShop.Services.Vendor;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class AuthController : ControllerBase
{
    private readonly IVendorService _vendorService;
    private readonly IJWTService _jWTService;
    private readonly IAdminService _adminService;

    public AuthController(
      IAdminService adminService,
      IVendorService vendorService,
      IJWTService jWTService)
    {
      _adminService=adminService;
      _vendorService=vendorService;
      _jWTService=jWTService;  
      
    }
 
    [HttpPost("Admin")]
    public async Task<IActionResult> LoginAdmin([FromBody]LoginDto admin)
    {
      try
      {
        
        var result= await _adminService.LoginAdmin(admin.Phone!,admin.Password!,HttpContext);
        if (!result.IsSuccess)
        {
          return NotFound(result.ErrorMessage);
        }
        var auth=new AuthDto()
        {
          Access=true,
          RefreshToken=null,
          AccessToken=result?.Data?.AccessToken,
          AccessTokenExpires=result?.Data?.Expires
        };
        return Ok(auth);
      }
      catch (System.Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
 
    [HttpPost("Vendor")]
    public async Task<IActionResult> LoginVendor([FromBody]LoginDto vendor)
    {
      try
      {
        var result =await _vendorService.LoginVendor(vendor.Phone!,vendor.Password!);
        var auth=new AuthDto()
        {
          Access=true,
          RefreshToken=null,
          AccessToken=result?.Data?.AccessToken,
          AccessTokenExpires=result?.Data?.Expires
        };
        return Ok(auth);
      }
      catch (System.Exception e)
      {
       return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
   
    [HttpGet("AdminSessions")]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> GetAllAdminSessions([FromQuery]Pagination pagination)
    {
      try
      {
        var data= _jWTService.Authenticate(HttpContext);
        var result= await _adminService.GetAllAdminSession(data!.Id,pagination.Limit,pagination.Page);
        
        var paginate= new ResponseBasePagenation<List<AdminSessionDto>>()
          {
            TotalPage=result.PageCount,
            CurrentPage=result.CurrentPageIndex,
            Data=result?.Data?.Select(ToAdminSessionDto).ToList()
          };
        return Ok(result);
      }
      catch (System.Exception e)
      {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
 
    [HttpGet("VendorSessions")]
    [Authorize(Roles=Roles.Vendor)]
    public async Task<IActionResult> GetAllVendorSession(Pagination pagination)
    {
      try
      {
        var data=_jWTService.Authenticate(HttpContext);
        var result = await _vendorService.GetAllVendorSession(data!.Id,pagination.Limit,pagination.Page);
        var paginate= new ResponseBasePagenation<List<VendorSessionDto>>()
        {
          CurrentPage=result.CurrentPageIndex,
          TotalPage=result.PageCount,
          Data=result?.Data?.Select(ToVendorSessionDto).ToList()
        };
        return Ok(paginate);
        
      }
      catch (System.Exception e)
      {
       return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
    
    [HttpDelete("VendorSession/{SessionId}")]
    [Authorize(Roles=Roles.Vendor)]
    public async Task<IActionResult> DeleteVendorSession([FromRoute]ulong SessionId)
    {
      try
      {
        var data=_jWTService.Authenticate(HttpContext);
        var session= await _vendorService.DeleteVendorSession(data!.Id,SessionId);
        if (!session.IsSuccess)
        {
          return NotFound(session.ErrorMessage);
        }
        return Ok(ToVendorSessionDto(session.Data!));
      }
      catch (System.Exception e)
      {
        
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
 
    [HttpDelete("AdminSession/{SessionId}")]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> DeleteAdminSession([FromRoute]ulong SessionId)
    {
      try
      {
        var data=_jWTService.Authenticate(HttpContext);
        var session= await _adminService.DeleteAdminSession(data!.Id,SessionId);
        if (!session.IsSuccess)
        {
          return NotFound(session.ErrorMessage);
        }
        return Ok(ToAdminSessionDto(session.Data!));
      }
      catch (System.Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
      }
    }
}