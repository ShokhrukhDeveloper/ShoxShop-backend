using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShoxShop.Const;

namespace ShoxShop.Services.JWT;
public class JWTService : IJWTService
{
    private readonly IConfiguration _config;
    public JWTService(IConfiguration config)
    {
        _config=config;
    }
    public JwtConst Authenticate(HttpContext httpContext)
    {
        try
        {
             var identity=httpContext.User.Identity as ClaimsIdentity;
             var claims=identity!.Claims;
             return new()
             {
                Id=ulong.Parse((claims.FirstOrDefault(w=>w.Type==ClaimTypes.NameIdentifier)
                ?? throw new NullReferenceException("Jwt Id is null")).Value),
                Role=(claims.FirstOrDefault(r=>r.Type==ClaimTypes.Role) 
                ?? throw new NullReferenceException("Jwt Role is null")).Value
             };
        }
        catch (System.Exception)
        {
            
        throw new Exception();
        }
    }

    public string GenerateToken(JwtConst claim)
    {
        var key=_config["Jwt:key"]?? throw new NullReferenceException("Jwt key is null");
        var issuer=_config["Jwt:Issuer"]??throw new NullReferenceException("Jwt Issuer is null");
        var audience=_config["Jwt:Audience"]??throw new NullReferenceException("Jwt Audience  is null");
        var securityKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials= new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
        var claims= new[]{
            new Claim(ClaimTypes.NameIdentifier,claim.Id.ToString()),
            new Claim(ClaimTypes.Role,claim.Role!),
        };
        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires:DateTime.Now.AddDays(10),
            signingCredentials:credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}