using System.ComponentModel.DataAnnotations;
#pragma warning disable
namespace ShoxShop.Dtos.User;
public class CreateUserDto
{
    [MaxLength(13)]
    [MinLength(13)]
    [Required]
    public string? Phone { get; set; }
    [MinLength(4)]
    [MaxLength(50)]
    [Required]
    public string? Password { get; set; }
    [MinLength(2)]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    [MinLength(2)]
    [MaxLength(50)]
    [Required]
    public string? LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }

    public string? UserName { get; set; }
    public IFormFile? Image { get; set; }
 
}