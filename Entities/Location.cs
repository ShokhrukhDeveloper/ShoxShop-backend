namespace ShoxShop.Entities
{
    public class Location
    {
        public ulong Id { get; set; }
        public ulong OwnerId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}