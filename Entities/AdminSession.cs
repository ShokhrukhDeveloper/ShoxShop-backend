namespace ShoxShop.Entities;
#pragma warning disable
public class AdminSession : EntityBase
{
    public ulong AdminSessionId { get; set; }
    public string? AccessToken { get; set; }
    public string? DeviceInfo { get; set; }
    public string? IPAddress { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expires { get; set; }
    public ulong AdminId { get; set; }
    public virtual Admin Admin { get; set; }
}