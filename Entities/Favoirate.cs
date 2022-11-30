namespace ShoxShop.Entities;
public class Favoirate : EntityBase
{
    public ulong FavoirateId { get; set; }
    public ulong ProductId { get; set; }
    public Product Product { get; set; }
    public ulong UserId { get; set; }
    public User User { get; set; }
    
}