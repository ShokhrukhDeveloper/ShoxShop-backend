namespace ShoxShop.Entities;
#pragma warning disable
public class LoginVendor : EntityBase
{
    public ulong Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public DateTime Expires { get; set; }
    public ulong VendorId{ get; set; }
    public Vendor Vendor { get; set; }
}