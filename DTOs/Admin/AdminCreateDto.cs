namespace ShoxShop.Dtos.Admin;
#pragma warning disable
public class AdminCreateDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Image { get; set; }
}