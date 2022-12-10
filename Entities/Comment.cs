namespace ShoxShop.Entities;
#pragma warning disable
public class Comment : EntityBase
{   
    
    public ulong CommentId { get; set; }
    public ulong UserId { get; set; }
    public User User { get; set; }
    public string? Title { get; set; } 
    public string Message { get; set; }
    public ulong ProductId { get; set; }
    public Product Product { get; set; }
}