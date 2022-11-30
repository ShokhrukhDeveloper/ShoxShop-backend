namespace ShoxShop.Entities;
public class LoginAdmin : EntityBase
{
    public ulong Id { get; set; }
    public string AdminName { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public ulong AdminId { get; set; }
    public Admin Admin { get; set; }

}