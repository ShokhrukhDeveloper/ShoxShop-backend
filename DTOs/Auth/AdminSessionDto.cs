namespace ShoxShop.Dtos.Auth;
public class AdminSessionDto
{
    public ulong AdminSessionId { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public DateTime? CareatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}