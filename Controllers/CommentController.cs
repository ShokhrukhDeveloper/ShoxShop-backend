using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoxShop.Const;
using ShoxShop.Dtos;
using ShoxShop.Dtos.Comment;
using ShoxShop.Services.CommentService;
using ShoxShop.Services.JWT;

namespace ShoxShop.Controllers;
[ApiController]
[Route("api/[controller]")]
public partial class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IJWTService _jWTService;

    public CommentController(ICommentService commentService,IJWTService jWTService)
    {
        _commentService=commentService;
        _jWTService=jWTService;
    }
    [HttpPost("{ProductId}")]
    // [Authorize(Roles =Roles.User)]
    public async Task<IActionResult> CreateComment([FromRoute]ulong ProductId,[FromBody]CreateCommentDto dto)
    {
        try
        {
            // var data = _jWTService.Authenticate(HttpContext)!;
            var result = await _commentService.CreateComment(
                1,// data.Id,
                ProductId,
                dto.Title,
                dto.Message
            );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToCommentDto(result.Data!));
        }
        catch (System.Exception e)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpPut("{ProductId}/{CommentId}")]
    // [Authorize(Roles =Roles.User)]
    public async Task<IActionResult> UpdateComment([FromRoute]ulong ProductId,[FromRoute]ulong CommentId,[FromBody]CreateCommentDto dto)
    {
        try
        {
            // var data = _jWTService.Authenticate(HttpContext)!;
            var result = await _commentService.UpdateComment(
                1,// data.Id,
                ProductId,
                CommentId,
                dto.Title,
                dto.Message
            );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToCommentDto(result.Data!));
        }
        catch (System.Exception e)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpDelete("{ProductId}/{CommentId}")]
    // [Authorize(Roles =Roles.User)]
    public async Task<IActionResult> DeleteComment([FromRoute]ulong ProductId,[FromRoute]ulong CommentId,[FromBody]CreateCommentDto dto)
    {
        try
        {
            // var data = _jWTService.Authenticate(HttpContext)!;
            var result = await _commentService.DeleteComment(
                1,//data.Id,
                ProductId,
                CommentId
            );
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(ToCommentDto(result.Data!));
        }
        catch (System.Exception e)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
    [HttpGet("{ProductId}")]
    // [Authorize(Roles =Roles.User)]
    public async Task<IActionResult> GetAllCommentById([FromRoute]ulong ProductId,[FromQuery]ushort Limit=10,[FromQuery]int Page=1)
    {
        try
        {
            // var data = _jWTService.Authenticate(HttpContext)!;
            var result = await _commentService.GetAllCommentByProductId(ProductId,Limit,Page);
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var paginate= new ResponseBasePagenation<List<CommentDto>>()
            {
                TotalPage=result.PageCount,
                CurrentPage=result.CurrentPageIndex,
                Data=result?.Data?.Select(ToCommentDto).ToList()
            };
            return Ok(paginate);
        }
        catch (System.Exception e)
        {
         return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = e.Message });
        }
    }
}