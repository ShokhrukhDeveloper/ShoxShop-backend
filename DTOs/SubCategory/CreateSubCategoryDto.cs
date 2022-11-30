namespace ShoxShop.Dtos.SubCategory;
public class CreatesubCategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ulong AdminId { get; set; }
    public string Image { get; set; }
    public bool Visiblity { get; set; }
    public ulong CetegoryId { get; set; }
}