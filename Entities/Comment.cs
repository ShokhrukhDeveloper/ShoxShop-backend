namespace ShoxShop.Entities;
public class Comment : EntityBase
{   
    
    public ulong CommentId { get; set; }
    public ulong UserId { get; set; }
    public ulong ProductId { get; set; }
    public string Title { get; set; } 
    public string Message { get; set; }
}