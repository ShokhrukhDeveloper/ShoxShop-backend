using ShoxShop.Model;
using ShoxShop.Dtos.Banner;

namespace ShoxShop.Services.Banner;
public interface IBannerService
{
    ValueTask<Result<BannerModel>> CreateBanner(BannerCreateDto bannerCreate);
    
    ValueTask<Result<List<BannerModel>>> GetAllBanner(ushort Limit,uint Page);
    ValueTask<Result<List<BannerModel>>> GetAllActiveBanner(ushort Limit=10,uint Page=10);
    ValueTask<Result<BannerModel>> DeleteBanner(ulong AdminId, ulong BannerId);
    ValueTask<Result<BannerModel>> GetBannerById(ulong BannerId);
    ValueTask<Result<BannerModel>> UpdateBanner(ulong BannerId,BannerCreateDto bannerCreate);
    
    


}