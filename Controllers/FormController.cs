using Microsoft.AspNetCore.Mvc;
using ShoxShop.Services.File;

namespace ShoxShop.Controllers;
[ApiController]
[Route("Api/upladi")]
public class FormController : ControllerBase
{
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult>FormFiles([FromForm]Forma forma)
    {
       var ser=new FileService();
       var result=await ser.SaveFile(forma.Image!);
        return await Task.FromResult( Ok(result));
    }
}
public class Forma
{
    
    public IFormFile? Image { get; set; }
    public string? Name { get; set; }
}