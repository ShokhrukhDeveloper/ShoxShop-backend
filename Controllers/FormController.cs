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
    public async Task<IActionResult> FormFiles(ulong forma=1)
    {
        _dbContext.ChangeTracker.LazyLoadingEnabled = true;
        var query=await _unitOfWork.
                    ProductRepository.
                    GetEntities.
                    Include(w=>w.SubCategory).
                    Include(w=>w.Likes).
                    Include(w=>w.Comments).
                    Include(s=>s.Images).
                    Include(w=>w.Vendor).
                    FirstOrDefaultAsync(d=>d.ProductId==forma);
        return  Ok(query);
    }
}
public class Forma
{
    
    public IFormFile? Image { get; set; }
    public string? Name { get; set; }
}