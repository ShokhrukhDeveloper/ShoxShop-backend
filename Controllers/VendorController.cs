using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Vendor;
using ShoxShop.Services.Vendor;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorController(IVendorService vendorService)
    {
        _vendorService=vendorService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateController(CreateVendorDto vendorDto)
    {
        try
        {
            var result = await _vendorService.CreateVendor(1,vendorDto);
            // if (!result.IsSuccess)
            // {
            //     return 
            // }
            return Ok(result);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}