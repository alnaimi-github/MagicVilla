namespace MagicVilla_VillaAPI.Models
{
    public class Villa
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Details { get; set; } = string.Empty;
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public string? ImageLocalPath { get; set; } = string.Empty;
        public string Amenity { get; set; } = string.Empty;
        public double Rate { get; set; }
    }
}
