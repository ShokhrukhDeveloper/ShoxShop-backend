using ShoxShop.Model;

namespace ShoxShop.Services.UserService;
public interface IUserService
{
    ValueTask<Result<UserSessionModel>> LoginUser(UserLoginModel userLogin);
    ValueTask<Result<UserSessionModel>> DeleteUserSession(ulong UserId,ulong SessionId);
    ValueTask<Result<UserModel>> GetUserDataByUserId(ulong UserId);
    // ValueTask<Result<FavoirateProductModel>> CreateFavoirateByUserId(ulong UserId,ulong ProductId);
    // ValueTask<Result<List<FavoirateProductModel>>> GetFavoiratesByUserId(ulong UserId, ushort Limit=10,uint Page=10);
    ValueTask<Result<ulong>> DeleteFavoirateById(ulong FavoirateId,ulong UserId);
    
    
}