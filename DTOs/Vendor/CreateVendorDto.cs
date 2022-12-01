namespace ShoxShop.Dtos.Vendor;
#nullable disable warnings
public class CreateVendorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string MarketName { get; set; }
}