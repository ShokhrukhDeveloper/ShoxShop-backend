namespace ShoxShop.Dtos.Banner;
public class BannerCreateDto 
{

    public ulong BannerId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public  bool Active { get; set; }
    public EBannerTypeDto BannerType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ulong AdminId { get; set; }
}