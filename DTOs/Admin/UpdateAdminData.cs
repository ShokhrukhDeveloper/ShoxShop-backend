namespace ShoxShop.Dtos.Admin;
#pragma warning disable
public class UpdateAdminData
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public IFormFile? Image { get; set; }
}