namespace ShoxShop.Model;
#nullable enable warnings
public class VendorSessionModel
{
    public ulong VendorSessionId { get; set; }
    public string? Token { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public ulong VendorId { get; set;}
}