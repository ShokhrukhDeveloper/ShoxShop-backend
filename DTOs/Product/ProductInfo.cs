using ShoxShop.Dtos.Category;
using ShoxShop.Dtos.Comment;
using ShoxShop.Dtos.Image;
using ShoxShop.Dtos.SubCategory;
#pragma warning disable
namespace ShoxShop.Dtos.Product;
public class ProductInfo
{
    public ulong ProductId { get; set; }
    public string? Name { get; set; }   
    public string? CoverImage { get; set; } // must be file
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool? Visiblity { get; set; }
    public CategoryDto CategoryId { get; set; }
    public SubCategoryDto SubCategoryId { get; set; }
    public int LikeCount { get; set; }
    public bool? YouLiked { get; set; }
    public List<CommentDto> Likes { get; set; }
    public List<ImageDto> Images { get; set; }
    
}