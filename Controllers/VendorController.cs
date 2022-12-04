using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos.Vendor;
using ShoxShop.Services.JWT;
using ShoxShop.Services.Vendor;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
    private readonly IVendorService _vendorService;
    private readonly IJWTService _jWTService;

    public VendorController(IVendorService vendorService,IJWTService jWTService)
    {
        _vendorService=vendorService;
        _jWTService=jWTService;
    }
    
    [HttpPost]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> CreateVendor(CreateVendorDto vendorDto)
    {
        try
        {
            var data=_jWTService.Authenticate(HttpContext)!;
            

            var result = await _vendorService.CreateVendor(data.Id,vendorDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(data);
        }
        catch (System.Exception e)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    // [HttpGet]
    // public Task<IActionResult> UpdateVendor()
    // {
    //     return OkResult();
    // }


}