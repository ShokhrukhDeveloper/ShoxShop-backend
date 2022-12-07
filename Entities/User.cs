namespace ShoxShop.Entities;
#pragma warning disable
public class User : EntityBase
{
    public ulong UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public Location Location { get; set; }
    public string UserName { get; set; }
    public string Image { get; set; }
    public bool? Blocked { get; set; }
    public LoginUser LoginUser { get; set; }
    public ICollection<Favoirate> Favoirates { get; set; }
    public ICollection<UserSession> UserSessions { get; set; }
}
