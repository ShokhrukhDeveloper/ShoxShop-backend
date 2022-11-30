namespace ShoxShop.Dtos.Category;
public class Category
{
    public ulong CategoryId { get; set; }
    public string  Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ulong AdminId { get; set; }
    public bool  Visiblity { get; set; }
}