namespace ShoxShop.Dtos.SubCategory;
public class CreateSubCategoryDto
{

    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public bool Visiblity { get; set; }
    public ulong CetegoryId { get; set; }
}