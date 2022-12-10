using ShoxShop.Entities;
using ShoxShop.Model;

namespace ShoxShop.Services.CommentService;
public partial class CommentService 
{
    CommentModel ToCommentModel(Comment comment)
        =>new()
        {
            CommentId=comment.CommentId,
            UserId=comment.UserId,
            ProductId=comment.ProductId,
            Title=comment.Title,
            Message=comment.Message,
            CreatedAt=comment.CreatedAt,
            UpdatedAt=comment.UpdatedAt
        };
}