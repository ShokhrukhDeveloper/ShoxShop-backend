namespace ShoxShop.Entities;
public class LoginUser : EntityBase
{
    public ulong Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public ulong? UserId { get; set; }
    public User User { get; set; }
}