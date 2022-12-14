namespace ShoxShop.Entities;
#pragma warning disable
public class SubCategory: EntityBase
{
    public ulong SubCategoryId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ulong AdminId { get; set; }
    public string Image { get; set; }
    public bool Visiblity { get; set; }
    public bool? Delete { get; set; }
    
    public ulong CetegoryId { get; set; }
    public Category? Category { get; set; }
    public List<Product>? Products { get; set; }
    
}