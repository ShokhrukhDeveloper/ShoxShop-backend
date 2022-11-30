namespace ShoxShop.Entities;
public class Admin:EntityBase
{
    public ulong AdminId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Image { get; set; }
    public string PhoneNumber { get; set; }
    public LoginAdmin AdminLogin { get; set; }
    public ICollection<Vendor> Vendors { get; set; }
}