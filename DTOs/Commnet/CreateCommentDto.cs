using System.ComponentModel.DataAnnotations;
#pragma warning disable
namespace ShoxShop.Dtos.Comment;
public class CreateCommentDto
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string Message { get; set; }
}