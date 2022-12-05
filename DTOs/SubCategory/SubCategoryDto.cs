namespace ShoxShop.Dtos.SubCategory;
#pragma warning disable


public class SubCategoryDto
{
    public ulong SubCategoryId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ulong AdminId { get; set; }
    public string? Image { get; set; }
    public ulong CategoryId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
#pragma warning restore 