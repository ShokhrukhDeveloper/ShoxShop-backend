namespace ShoxShop.Entities;
public class Category : EntityBase
{
    public ulong CategoryId { get; set; }
    public string  Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ulong AdminId { get; set; }
    public bool  Visiblity { get; set; }
    public bool? Delete { get; set; }
    
    public ICollection<SubCategory> SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }

}