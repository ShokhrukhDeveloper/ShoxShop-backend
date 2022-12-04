using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace ShoxShop.Dtos.Vendor;
public class UpdateVendorDto
{
    [MaxLength(length:20)]
    [MinLength(2)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(length:20)]
    [MinLength(2)]
    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }
    
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    
    [Required]
    [Phone]
    public string Phone { get; set; }
    
    [MinLength(3)]
    public string? Address { get; set; }
    
    public string? Image { get; set; }
    [MinLength(3)]
    [MaxLength(50)]
    public string MarketName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}