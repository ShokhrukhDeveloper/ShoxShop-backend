namespace ShoxShop.Entities;
public class User : EntityBase
{
    public ulong UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Adderss { get; set; }
    public Location Location { get; set; }
    public string UserName { get; set; }
    public string Image { get; set; }
    public bool? Blocked { get; set; }

    public ICollection<UserSession> UserSessions { get; set; }
}
