using System.ComponentModel.DataAnnotations;

namespace ShoxShop.Dtos.SubCategory;
#pragma warning disable
public class CreateSubCategoryDto
{
    [Required][MaxLength(50)][MinLength(2)]
    public string Name { get; set; }
    [MaxLength(255)][MinLength(2)]
    public string Description { get; set; }
    public string? Image { get; set; }
    public bool Visiblity { get; set; }
    public ulong CetegoryId { get; set; }
}