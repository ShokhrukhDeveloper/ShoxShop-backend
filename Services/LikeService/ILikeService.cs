using ShoxShop.Model;

namespace ShoxShop.Services.LikeService;
public interface ILikeService
{
    ValueTask<Result<bool>> Like(ulong userId,ulong ProductId);
    
}