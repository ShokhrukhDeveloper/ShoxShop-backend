namespace ShoxShop.Services.Location;
using ShoxShop.Model;
public interface ILocationService
{
    ValueTask<LocationModel> UpdateLocation(ulong UsedId,double latitude,double longitude);
    ValueTask<LocationModel> DeteleLocation(ulong UsedId,double latitude,double longitude); 
}