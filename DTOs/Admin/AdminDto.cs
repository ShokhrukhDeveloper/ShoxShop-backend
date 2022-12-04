namespace ShoxShop.Dtos.Admin;
#pragma warning disable

public class AdminDto
{
    public ulong AdminId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }
}