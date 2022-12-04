namespace ShoxShop.Model;
#pragma warning disable
public class CategoryModel 
{
    public ulong CategoryId { get; set; }
    public string  Name { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public ulong? AdminId { get; set; }
    public bool?  Visiblity { get; set; }
    public bool? Delete { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}