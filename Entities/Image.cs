namespace ShoxShop.Entities;
public class Image : EntityBase
{
   public ulong ImageId { get; set; }
   public string ImageUrl { get; set; }
   public string Desription { get; set; }

   public ulong ProductId { get; set; }
   public Product Product { get; set; }

}