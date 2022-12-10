using System.ComponentModel.DataAnnotations;
#pragma warning disable
namespace ShoxShop.Dtos.Product;
public class CreateProductDto
{
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public string Name { get; set; } 
    public IFormFile? CoverImage { get; set; }
    
    [MinLength(2)]
    [Required]
    public string? Description { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public bool Visiblity { get; set; }
    [Required]
    public ulong SubCategoryId { get; set; }
}