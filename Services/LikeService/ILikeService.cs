using ShoxShop.Model;

namespace ShoxShop.Services.ILikeService;
public interface ILikeService
{
    ValueTask<Result<bool>> Like(ulong userId,ulong ProductId);
}