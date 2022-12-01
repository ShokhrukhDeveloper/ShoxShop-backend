namespace ShoxShop.Model;
public class AdminLoginModel
{
public ulong AdminSessionId { get; set; }
    public string? Token { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public ulong AdminId { get; set; }
}