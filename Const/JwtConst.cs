namespace ShoxShop.Const;
public  class JwtConst
{
  public JwtConst()
  {
    
  }
  public JwtConst(ulong Id,string Role)
  {
    this.Id=Id;
    this.Role=Role;
  }
  public ulong Id { get; set; }  
  public string? Role { get; set; }  
}
public static class Roles
{
    public const string Admin="Admin";
    public const string Vendor="Vendor";
    public const string User="User";   
}