namespace ShoxShop.Entities;
public class Banner : EntityBase
{

    public ulong BannerId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public  bool Active { get; set; }
    public EBannerType BannerType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ulong AdminId { get; set; }
    public Admin Admin { get; set; }
}
