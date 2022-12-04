namespace ShoxShop.Dtos.Category;
#pragma warning disable
public class CategoryDto
{
    public ulong CategoryId { get; set; }
    public string?  Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}