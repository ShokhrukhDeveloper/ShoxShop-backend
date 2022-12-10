namespace ShoxShop.Dtos.Image;
#pragma warning disable
public class UploadImageDto
{
    public ICollection<IFormFile> images {get; set;}
    public string? Title { get; set; } 
    public string? Description { get; set; } 
}