namespace ShoxShop.Entities
{
    public class Location :EntityBase
    {
        public ulong LocationId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ulong UserId { get; set; }
        public User User { get; set; }
        
    }
}