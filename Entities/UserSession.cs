namespace ShoxShop.Entities;
public class UserSession : EntityBase
{
    public ulong UserSessionId { get; set; }
    public string AccessToken { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public ulong UserId { get; set; }
    public User User { get; set; }
}