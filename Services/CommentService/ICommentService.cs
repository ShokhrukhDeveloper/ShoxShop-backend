using ShoxShop.Model;

namespace ShoxShop.Services.CommentService;
public interface ICommentService
{
    ValueTask<Result<CommentModel>> CreateComment(
                            ulong UserId, 
                            ulong ProductId,
                            string Title,
                            string Message
                            );
    ValueTask<Result<CommentModel>> DeleteComment(
                            ulong UserId,
                            ulong ProductId, 
                            ulong CommentId);
    ValueTask<Result<CommentModel>> UpdateComment(
                            ulong UserId, 
                            ulong ProductId, 
                            ulong CommentId,
                            string Title,
                            string Message
                            );
    ValueTask<Result<List<CommentModel>>> GetAllCommentByProductId(ulong ProductId,ushort Limit=10,int Page=1);
    
}