using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ShoxShop.Entities;

namespace ShoxShop.Data;
public class ApplicationDbContext :DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
   { } 
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
   }
   public DbSet<Admin> Admins { get; set; }
   public DbSet<Category> Categories { get; set; }
   public DbSet<Comment> Comments { get; set; }
   public DbSet<Favoirate> Favoirates { get; set; }
   public DbSet<Image> Images { get; set; }
   public DbSet<Like> Likes { get; set; }
   public DbSet<Location> Locations { get; set; }
   public DbSet<Product> Products { get; set; }
   public DbSet<SubCategory> SeubCategories { get; set; }
   public DbSet<User> Users { get; set; }
   public DbSet<UserSession> UserSessions { get; set; }
   public DbSet<Vendor> Vendors { get; set; }
   public DbSet<VendorSession> VendorSessions { get; set; }
}