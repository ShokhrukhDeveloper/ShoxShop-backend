using ShoxShop.Const;

namespace ShoxShop.Services.JWT;
public interface IJWTService
{
    string GenerateToken(JwtConst calims);
    JwtConst? Authenticate (HttpContext httpContext);
}