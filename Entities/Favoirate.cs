namespace ShoxShop.Entities;
public class Favoirate : EntityBase
{
    public ulong FavoirateId { get; set; }
    public ulong UserId { get; set; }
    public ulong ProductId { get; set; }
}