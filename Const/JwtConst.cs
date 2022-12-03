namespace ShoxShop.Const;
public  class JwtConst
{
  public ulong Id { get; set; }  
  public string Role { get; set; }  
}
public static class Roles
{
    public static string Admin="Admin";
    public static string Vendor="Vendor";
    public static string User="User";   
}