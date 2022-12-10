namespace ShoxShop.Model;
public class CommentModel
{   
    public ulong CommentId { get; set; }
    public ulong UserId { get; set; }
    public string? Title { get; set; } 
    public string? Message { get; set; }
    public ulong ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}