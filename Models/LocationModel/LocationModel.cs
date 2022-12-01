namespace ShoxShop.Model;
public class LocationModel
{
        public ulong LocationId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ulong UserId { get; set; }
}