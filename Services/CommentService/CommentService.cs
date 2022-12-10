using Microsoft.EntityFrameworkCore;
using ShoxShop.Entities;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.CommentService;
public partial class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CommentService> _logger;

    public CommentService(IUnitOfWork unitOfWork, ILogger<CommentService> logger)
    {
        _unitOfWork=unitOfWork;
        _logger=logger;
    }
    public async ValueTask<Result<CommentModel>> CreateComment(ulong UserId, ulong ProductId, string Title, string Message)
    {
        try
        {
            var product = _unitOfWork.ProductRepository.GetById(ProductId);
            if (product is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given Id Product not Found"
                };
            } 
            var comment= new Comment()
            {
                Title=Title,
                Message=Message,
                ProductId=ProductId,
                UserId=UserId
            };
            var newComment= await _unitOfWork.CommentRepository.AddAsync(comment);
            return new(true)
            {
                Data=ToCommentModel(newComment)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(CreateComment)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<CommentModel>> DeleteComment(ulong UserId, ulong ProductId, ulong CommentId)
    {
      try
        {
            
            var comment= await _unitOfWork.
                    CommentRepository.
                    GetEntities.
                    FirstOrDefaultAsync(
                        e=>
                            e.UserId==UserId&&
                            e.ProductId==ProductId&&
                            e.CommentId==CommentId
                                        );
            if (comment is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given Commnet Id product and User Id Not found"
                };
            }
            var deletedComment= await _unitOfWork.CommentRepository.Remove(comment);
            return new(true)
            {
                Data=ToCommentModel(deletedComment)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(DeleteComment)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }  
    }

    public async ValueTask<Result<List<CommentModel>>> GetAllCommentByProductId(ulong ProductId, ushort Limit = 10, int Page = 1)
    {
       try
        {
            
            var query=  _unitOfWork.
                    CommentRepository.
                    GetEntities.
                    Where(e=>e.ProductId==ProductId);
            var counts=query.Count();
            var comments= await query.
                                Skip((Page-1)*Limit).
                                Take(Limit).ToListAsync();
           
            var TotalPage= (int)Math.Ceiling(counts/(double)Limit);
            return new(true)
            {
                CurrentPageIndex=Page,
                PageCount=TotalPage,
                Data=comments.Select(ToCommentModel).ToList()
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(GetAllCommentByProductId)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        }
    }

    public async ValueTask<Result<CommentModel>> UpdateComment(ulong UserId, ulong ProductId, ulong CommentId, string? Title, string? Message)
    {
              try
        {
            
            var comment= await _unitOfWork.
                    CommentRepository.
                    GetEntities.
                    FirstOrDefaultAsync(
                        e=>
                            e.UserId==UserId&&
                            e.ProductId==ProductId&&
                            e.CommentId==CommentId
                                        );
            if (comment is null)
            {
                await _unitOfWork.RollbackAsync();
                return new(false)
                {
                    ErrorMessage="Given Commnet Id product and User Id Not found"
                };
            }
            comment.Message=Message??comment.Message;
            comment.Title=Title??comment.Title;
            var updatedComment= await _unitOfWork.CommentRepository.Update(comment);
            return new(true)
            {
                Data=ToCommentModel(updatedComment)
            };
        }
        catch (System.Exception e)
        {
         _logger.LogError($"Error occured at: {nameof(DeleteComment)}  ErrorMessage: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occurred server please contact support"
            };
        } 
    }
}