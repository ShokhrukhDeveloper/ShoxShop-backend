using ShoxShop.Dtos.Admin;
using ShoxShop.Dtos.User;
using ShoxShop.Model;

namespace ShoxShop.Services.UserService;
public interface IUserService
{
    ValueTask<Result<UserModel>> CreateUser(CreateUserDto dto);
    ValueTask<Result<UserSessionModel>> LoginUser(LoginDto userLogin);
    ValueTask<Result<UserSessionModel>> DeleteUserSession(ulong UserId,ulong SessionId);
    ValueTask<Result<UserModel>> GetUserDataByUserId(ulong UserId);
    ValueTask<Result<List<UserSessionModel>>> GetUserSessionByUserId(ulong UserId,ushort Limit=10,int Page=10); 
    ValueTask<Result<ProductModel>> CreateFavoirateByUserId(ulong UserId,ulong ProductId);
    ValueTask<Result<List<ProductModel>>> GetFavoiratesByUserId(ulong UserId, ushort Limit=10,int Page=10);
    ValueTask<Result<bool>> DeleteFavoirateById(ulong ProductId,ulong UserId);
}