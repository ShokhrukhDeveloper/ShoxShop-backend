namespace ShoxShop.Dtos.Admin;
public class GetTokenDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpires { get; set; }
    public string RefreshToken { get; set; }
    public bool Access { get; set; }
}