using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Vendor;
using ShoxShop.Services.JWT;
using ShoxShop.Services.Vendor;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class VendorController : ControllerBase
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
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToVendorDto(result.Data!));
        }
        catch (System.Exception e)
        {
            
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    
    
    [HttpPut]
    public async Task<IActionResult> UpdateVendor([FromBody]UpdateVendorDto updateVendor)
    {
        try
        {
            var data=_jWTService.Authenticate(HttpContext)!;
            var result= await _vendorService.UpdateVendor(data.Id, updateVendor);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToVendorDto(result.Data!));
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

    [HttpGet("{Id}")]
    [Authorize(Roles =Roles.Admin)]
    public async Task<IActionResult> GetById(ulong Id)
    {
        try
        {
          var result= await _vendorService.GetVendorById(Id);
          if (!result.IsSuccess)
          {
            return NotFound(result.ErrorMessage);
          }
          return Ok(ToVendorDto(result.Data!));  
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });

        }
    }
    [HttpGet("All")]
    [Authorize(Roles =Roles.Admin)]
    public async Task<IActionResult> GetAllVendor([FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            var result = await _vendorService.GetAll(Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var page= new ResponseBasePagenation<List<VendorDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data?.Select(ToVendorDto).ToList()
            };
            return Ok(page);
        }
        catch (System.Exception e)
        { 
            return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpGet("Search")]
    public async Task<IActionResult> Search(string text)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return NotFound("Given text is null or empty :😊😊😊😊");
            }
            var result= await _vendorService.Search(text);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var page= new ResponseBasePagenation<List<VendorDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result.Data?.Select(ToVendorDto).ToList()
            };
            return Ok(page);
        }
        catch (System.Exception e)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }

}