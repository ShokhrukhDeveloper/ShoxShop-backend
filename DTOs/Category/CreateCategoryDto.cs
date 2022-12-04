using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace ShoxShop.Dtos.Category;
public class CreateCategoryDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string  Name { get; set; }
    public string? Description { get; set; }
    public string Image { get; set; }

    public bool  Visiblity { get; set; }=true;
}