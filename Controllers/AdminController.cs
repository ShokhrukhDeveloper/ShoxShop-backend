using Microsoft.AspNetCore.Mvc;
using ShoxShop.Dtos.Admin;
using ShoxShop.Services.Admin;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IUnitOfWork _adminService;

    public AdminController(IUnitOfWork unitOfWork)
    {
        _adminService=unitOfWork;
    }
    [HttpPost]
    public IActionResult LoginAdmin()
    {
        try
        {
           return Ok(_adminService.AdminRepository.GetEntities.ToList());
        }
        catch (System.Exception e)
        {
            
            throw;
        }
        return Ok();
    }
}