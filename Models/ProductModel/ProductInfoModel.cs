using ShoxShop.Dtos.Vendor;

namespace ShoxShop.Model;
#pragma warning disable
public class ProductInfoModel
{
    public ulong ProductId { get; set; }
    public string? Name { get; set; }   
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool? Visiblity { get; set; }
    public CategoryModel? Category { get; set; }
    public SubCategoryModel? SubCategory { get; set; }
    public VendorModel? Vendor { get; set; }
    public int LikeCount { get; set; }
    public bool? YouLiked { get; set; }
    public List<CommentModel> Likes { get; set; }
    public List<ImageModel>? Images { get; set; }
    
}