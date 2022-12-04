using System.ComponentModel.DataAnnotations;

namespace ShoxShop.Dtos.Admin;
public class LoginDto
{
    [MaxLength(13)]
    [MinLength(13)]
    [Required]
    public string? Phone { get; set; }
    [MinLength(4)]
    [MaxLength(50)]
    [Required]
    public string? Password { get; set; }
}