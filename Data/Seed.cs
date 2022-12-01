using ShoxShop.Entities;
#nullable disable warnings
namespace ShoxShop.Data.Seed;
public static class Seed
{
    public static void Init(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope=applicationBuilder.ApplicationServices.CreateAsyncScope())
        {
         var context= serviceScope.ServiceProvider.GetService<ApplicationDbContext>();  
            if (!context.Admins.Any())
            {
                
                
               var result = context.Admins.Add(
                    new (){
                        FirstName="Admin",
                        LastName="admin",
                        BirthDate=DateTime.Now,
                        PhoneNumber="+998997531097",
                        Image="null"
                    }
                );
                context.SaveChanges();
                context.LoginAdmins.Add(
                    new(){
                        AdminId=result.Entity.AdminId,
                        Password="1234",
                        Phone=result.Entity.PhoneNumber,
                        PasswordHash="skgdfgsdfg;lsdf;lg;sdfg;sd;fg;sdlfg"    
                    }
                );
                context.SaveChanges();
            } 
        }
    }
}