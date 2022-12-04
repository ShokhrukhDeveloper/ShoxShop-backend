namespace ShoxShop.Dtos.Vendor;
#pragma warning disable
public class VendorDto
{
    public ulong VendorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
    public string MarketName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

}
#pragma warning restore