namespace ShoxShop.Entities;
#pragma warning disable
public class VendorSession : EntityBase
{
    public ulong VendorSessionId { get; set; }
    public string AccessToken { get; set; }
    public string DeviceInfo { get; set; }
    public string IPAddress { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public ulong VendorId { get; set;}
    public Vendor Vendor { get; set; }
}