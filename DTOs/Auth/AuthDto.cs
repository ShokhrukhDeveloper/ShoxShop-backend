namespace ShoxShop.Dtos.Auth;
#pragma warning disable 
public class AuthDto
{
    public string? AccessToken { get; set; }
    public DateTime? AccessTokenExpires { get; set; }
    public string? RefreshToken { get; set; }
    public bool? Access { get; set; }
}
#pragma warning restore 