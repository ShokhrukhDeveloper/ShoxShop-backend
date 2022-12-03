using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos.Admin;
using ShoxShop.Services.Admin;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{


    public AdminController()
    {}
    [HttpPost]
    [Authorize(Roles=Roles.Admin)]
    public async Task<IActionResult> LoginAdmin(string phone,string password)
    {
        return await Task.FromResult(Ok("Success"));
    }
}