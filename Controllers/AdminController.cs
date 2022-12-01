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
    public async Task<IActionResult> LoginAdmin(string phone,string password)
    {
        var ser=new AdminService(_adminService);
        try
        {
            var res=await ser.LoginAdmin(phone,password);
           return Ok(res);
        }
        catch (System.Exception e)
        {
            
            throw;
        }
    }
}