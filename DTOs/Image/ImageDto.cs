namespace ShoxShop.Dtos.Image;
#pragma warning disable
public class ImageDto
{
    public ulong ImageId { get; set; }
   public string ImageUrl { get; set; }
   public string  Title { get; set; }
   public string? Desription { get; set; }

   public ulong ProductId { get; set; }
}