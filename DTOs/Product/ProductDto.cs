namespace ShoxShop.Dtos.Product;
public class ProductDto
{
    public ulong ProductId { get; set; }
    public string Name { get; set; }   
    public string CoverImage { get; set; } // must be file
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool Visiblity { get; set; }
    public ulong SubCategoryId { get; set; }
}