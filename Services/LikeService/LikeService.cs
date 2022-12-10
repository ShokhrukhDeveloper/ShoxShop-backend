using Microsoft.EntityFrameworkCore;
using ShoxShop.Entities;
using ShoxShop.Model;
using ShoxShop.UnitOfWork;

namespace ShoxShop.Services.LikeService;
public class LikeService : ILikeService
{
    private readonly ILogger<LikeService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public LikeService(ILogger<LikeService>logger,IUnitOfWork unitOfWork)
    {
        _logger=logger;
        _unitOfWork=unitOfWork;
    }
    public async ValueTask<Result<bool>> Like(ulong userId, ulong ProductId)
    {
        try
        {
            var like= await _unitOfWork.
                    LikeRepository.
                    GetEntities.
                    FirstOrDefaultAsync(e=>e.ProductId==ProductId&&e.UserId==userId);
            if (like is null)
            {
               await _unitOfWork.RollbackAsync();
               return new(true)
                        {
                            ErrorMessage="you are allready liked this project",
                            Data=true
                        };
            }
            var liked= new Like()
                    {
                        ProductId=ProductId,
                        UserId=userId
                    };
            await _unitOfWork.LikeRepository.AddAsync(liked);
            await _unitOfWork.RollbackAsync();
               return new(true)
                        {
                            Data=true
                        };
        }
        catch (System.Exception e)
        {
            _logger.LogError($"Error occured at: {nameof(Like)} mehod reason: {e.Message}");
            return new(false)
            {
                ErrorMessage="Error occured server plaese contact support"
            };
        }
    }
}