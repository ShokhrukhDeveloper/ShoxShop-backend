namespace ShoxShop.Dtos;
public class ResponseBasePagenation<TData> where TData : class
{
    public int? CurrentPage { get; set; }
    public int? TotalPage { get; set; }
    public Error? Error { get; set; }
    public TData? Data { get; set; }
}