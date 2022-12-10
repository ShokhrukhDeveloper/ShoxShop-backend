using System.ComponentModel.DataAnnotations;
#pragma warning disable
namespace ShoxShop.Dtos.Product;
public class UpdateProductDto
{
    
    public string? Name { get; set; } 
    public IFormFile? CoverImage { get; set; }
    public string? Description { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public bool? Visiblity { get; set; }
}