using System.ComponentModel.DataAnnotations;

namespace ShoxShop.Dtos.Vendor;
#nullable disable warnings
public class CreateVendorDto
{
    [Required]
    [MaxLength(20)]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(20)]
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [Phone]
    public string Phone { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string Password { get; set; }
    [MinLength(2)]
    [MaxLength(255)]
    [Required]
    public string Address { get; set; }
    [Required]
    [MaxLength(255)]
    [MinLength(2)]
    public string MarketName { get; set; }
}