namespace ShoxShop.Dtos.Category;
public class CreateCategoryDto
{
    public string  Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public bool  Visiblity { get; set; }
    public bool? Delete { get; set; }
}