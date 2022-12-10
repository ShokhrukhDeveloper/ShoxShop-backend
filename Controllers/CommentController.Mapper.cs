using ShoxShop.Dtos.Comment;
using ShoxShop.Model;

namespace ShoxShop.Controllers;
public partial class CommentController
{
    CommentDto ToCommentDto(CommentModel comment)
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