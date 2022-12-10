using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoxShop.Data;
using ShoxShop.Entities;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/upload")]
public class FormController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UnitOfWork.UnitOfWork _unitOfWork;
    public FormController(ApplicationDbContext dbContext)
    {
        _dbContext=dbContext;
        _unitOfWork = new UnitOfWork.UnitOfWork(dbContext);
    }

    [HttpGet]
    [Produces("application/json")]
    public IActionResult FormFiles(ulong forma=1)
    {
       var result= _dbContext.Admins.
                Include(e=>e.Vendors)
                .Where(e=>e.AdminId==forma).FirstOrDefault(); 
        return  Ok(result);
    }
}
public class Forma
{
    
    public IFormFile? Image { get; set; }
    public string? Name { get; set; }
}