namespace ShoxShop.Dtos.SubCategory;
public class SubCategoryDto
{
    public ulong SubCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ulong AdminId { get; set; }
    public string Image { get; set; }
    public ulong CetegoryId { get; set; }
}