namespace ShoxShop.Entities;
public class LoginVendor : EntityBase
{
    public ulong Id { get; set; }
    public string VendorName { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    
    public ulong VendorId{ get; set; }
    public Vendor Vendor { get; set; }
}