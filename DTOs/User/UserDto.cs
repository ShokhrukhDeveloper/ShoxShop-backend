namespace ShoxShop.Dtos.User;
#pragma warning disable
public class UserDto
{
    public ulong UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? UserName { get; set; }
    public string? Image { get; set; }
}