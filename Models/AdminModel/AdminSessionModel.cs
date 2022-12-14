namespace ShoxShop.Model;
public class AdminSessionModel
{
public ulong AdminSessionId { get; set; }
    public string? AccessToken { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ulong AdminId { get; set; }
}