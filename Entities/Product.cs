namespace ShoxShop.Entities;
#pragma warning disable
public class Product : EntityBase
{
    public ulong ProductId { get; set; }
    public string Name { get; set; }   
    public string Model { get; set; }
    public string? CoverImage { get; set; } 
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? NewPrice { get; set; }
    public bool Visiblity { get; set; }
    public bool? Delete { get; set; } 
    public ulong SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }

    public ulong CategoryId { get; set; }
    public Category Category { get; set; }
    public ulong VendorId { get; set; }
    public Vendor Vendor { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Image> Images { get; set; }
}