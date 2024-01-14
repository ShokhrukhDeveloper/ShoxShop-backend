using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ShoxShop.Entities;
using ShoxShop.Extension;
#pragma warning disable
namespace ShoxShop.Data;
public class ApplicationDbContext :DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
   {} 
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
   }
   public DbSet<Admin> Admins { get; set; }
   public DbSet<Banner> Banners { get; set; }
   public DbSet<AdminSession> AdminSessions { get; set; }
   public DbSet<Category> Categories { get; set; }
   public DbSet<Comment> Comments { get; set; }
   public DbSet<Favoirate> Favoirates { get; set; }
   public DbSet<Image> Images { get; set; }
   public DbSet<Like> Likes { get; set; }
   public DbSet<Location> Locations { get; set; }
   public DbSet<Product> Products { get; set; }
   public DbSet<SubCategory> SubCategories { get; set; }
   public DbSet<User> Users { get; set; }
   public DbSet<UserSession> UserSessions { get; set; }
   public DbSet<Vendor> Vendors { get; set; }
   public DbSet<VendorSession> VendorSessions { get; set; }
   public DbSet<LoginAdmin> LoginAdmins { get; set; }
   public DbSet<LoginVendor> LoginVendors { get; set; }
   public DbSet<LoginUser> LoginUsers { get; set; }
   public override int SaveChanges()
   {
      NameHash();
      SetDateTime();
      return base.SaveChanges();
   }
   public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
   {
      NameHash();
      SetDateTime();
      return base.SaveChangesAsync(cancellationToken);
   }
   private void SetDateTime()
   {
      foreach (var entry in ChangeTracker.Entries<EntityBase>())
      {
         if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = null;
            }

            if(entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
      }
   }
   private void NameHash()
   {
      foreach(var entry in ChangeTracker.Entries<LoginUser>())
        {
            if(entry.Entity is LoginUser login)
                login.PasswordHash = login.Password.ToSha256();
        }
      foreach(var entry in ChangeTracker.Entries<LoginAdmin>())
        {
            if(entry.Entity is LoginAdmin login)
                login.PasswordHash = login.Password.ToSha256();
        }
      foreach(var entry in ChangeTracker.Entries<LoginVendor>())
        {
            if(entry.Entity is LoginVendor login)
                login.PasswordHash = login.Password.ToSha256();
        }
   }

}
