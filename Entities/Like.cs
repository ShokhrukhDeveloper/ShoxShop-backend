namespace ShoxShop.Entities;
public class Like : EntityBase
{
    public ulong LikeId { get; set; }
    public ulong UserId { get; set; }
    
    public ulong ProductId { get; set; }
    public Product Product { get; set; }

}