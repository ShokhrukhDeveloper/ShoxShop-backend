namespace ShoxShop.Dtos.Category;
public class CategoryDto
{
    public ulong CategoryId { get; set; }
    public string  Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public ulong AdminId { get; set; }
}