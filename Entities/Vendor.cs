namespace ShoxShop.Entities;
public class Vendor : EntityBase
{
    public ulong VendorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public string Profile { get; set; }
    public bool? Blocked { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public ulong AdminId { get; set; }
    public Admin Admin { get; set; }
    public ICollection<VendorSession> VendorSessions { get; set; }
}