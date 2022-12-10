using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace ShoxShop.Dtos.Vendor;
public class UpdateVendorDto
{
    [MaxLength(length:20)]
    [MinLength(2)]
    public string? FirstName { get; set; }
    [MaxLength(length:20)]
    [MinLength(2)]
    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [Phone]
    public string? Phone { get; set; }
    
    [MinLength(3)]
    public string? Address { get; set; }
    
    public IFormFile? Image { get; set; }
    [MinLength(2)]
    [MaxLength(50)]
    public string? MarketName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}